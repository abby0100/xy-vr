package com.xy.unity;

import android.os.Bundle;
import android.widget.Toast;

import com.unity3d.player.UnityPlayerActivity;

public class MainActivity extends UnityPlayerActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
//        setContentView(R.layout.activity_main);

        testUnityAndroid("");
    }

    private void testUnityAndroid(String text) {
        Toast.makeText(MainActivity.this, "testUnityAndroid", Toast.LENGTH_LONG).show();
    }
}
