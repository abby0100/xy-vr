var port = process.env.PORT || 3000;
var io = require('socket.io')(port);
var shortId = require('shortid');

var players = [];

var playerSpeed = 3;

console.log("server started on port " + port);

io.on('connection', function (socket) {
    
    var thisPlayerId = shortId.generate();
    console.log("====================== BEGIN =================================");
    console.log("client connected, id = ", thisPlayerId);
   
    socket.emit('register', {id:thisPlayerId});
    socket.broadcast.emit('spawn', {id:thisPlayerId});
    socket.broadcast.emit('requestPosition');
    
    for(var playerId in players){
        if(playerId == thisPlayerId)
            continue;
        socket.emit('spawn', players[playerId]);
    };
    
    
    socket.on('disconnect', function () {
        console.log('client disconected');
        delete players[thisPlayerId];
        socket.broadcast.emit('disconnected', {id:thisPlayerId});
	console.log("====================== E N D =================================");
    });
});

