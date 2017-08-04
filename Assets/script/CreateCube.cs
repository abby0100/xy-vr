using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateCube : MonoBehaviour {

	private ArrayList arrayListXYZ = new ArrayList();
	private ArrayList arrayListRGB = new ArrayList();
	private Vector3 xyz;
	private Color colorRGB;
	private int numPoints = 60000;	
	//private int numPoints = 360;

	// Use this for initialization
	void Start () {
	
		// 1. 读取数据
		//readData();
//		readCubeDataFromFile();
		readLungDataFromFile();

		// 2. 渲染
		renderData();

	}

	private void createSemphere(float x, float y, float z) {
		Debug.Log("xy ==> createSemphere");

		//我们将obj1初始化为一个Cube立方体，当然我们也可以初始化为其他的形状  
		GameObject obj1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);  
		//设置物体的位置Vector3三个参数分别代表x,y,z的坐标数  
		obj1.transform.position = new Vector3(x,y,z);  
		//给这个创建出来的对象起个名字  
		obj1.name = "dujia";  
		//设置物体的tag值，在赋值之前要在Inspector面板中注册一个tag值  
		//注册tag值得方法，用鼠标选中摄像机对象在Inspector面板中找到tag，选addtag  
		obj1.tag = "shui";  
		//设置物体贴图要图片文件放在(Resources）文件夹下，没有自己创建  
		//obj1.renderer.material.mainTexture = (Texture)Resources.Load("psb20");	
	}

	private void renderData() {
		Debug.Log("xy ==> 2 renderData");

		int num = arrayListRGB.Count;
		Debug.Log("xy ==> renderData num=" + num);
		Debug.Log("xy ==> renderData numPoints=" + numPoints);
		int meshNum = num / numPoints;
		int leftPointsNum = num % numPoints;
		Debug.Log("xy ==> renderData meshNum=" + meshNum);
		Debug.Log("xy ==> renderData leftPointsNum=" + meshNum);
		int i = 0;

		for (; i < meshNum; i++)
		{
			Debug.Log("xy ==> renderData i=" + i);
			GameObject obj = new GameObject();
			obj.name = i.ToString();
			obj.AddComponent<MeshFilter>();
			obj.AddComponent<MeshRenderer>();
			Mesh tempMesh = new Mesh();
			CreateMesh(ref tempMesh, ref arrayListXYZ, ref arrayListRGB, i * numPoints, numPoints);
			Material material = new Material(Shader.Find("Custom/VertexColor"));
			obj.GetComponent<MeshFilter>().mesh = tempMesh;
			obj.GetComponent<MeshRenderer>().material = material;
		}

		Debug.Log("xy ==> renderData objLeft");
		GameObject objLeft = new GameObject();
		objLeft.name = i.ToString();
		objLeft.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
		objLeft.AddComponent<MeshFilter>();
		objLeft.AddComponent<MeshRenderer>();
		Mesh tempMeshLeft = new Mesh();
		CreateMesh(ref tempMeshLeft, ref arrayListXYZ, ref arrayListRGB, i * numPoints, leftPointsNum);
		Material materialLeft = new Material(Shader.Find("Custom/VertexColor"));
		objLeft.GetComponent<MeshFilter>().mesh = tempMeshLeft;
		objLeft.GetComponent<MeshRenderer>().material = materialLeft;
	}

	void CreateMesh(ref Mesh mesh, ref ArrayList arrayListXYZ, ref ArrayList arrayListRGB, int beginIndex, int pointsNum)
	{
		Debug.Log("xy ==> CreateMesh");

		Vector3[] points = new Vector3[pointsNum];
		Color[] colors = new Color[pointsNum];
		int[] indecies = new int[pointsNum];
		for (int i = 0; i < pointsNum; ++i)
		{
			points[i] = (Vector3)arrayListXYZ[beginIndex + i];
			indecies[i] = i;
			colors[i] = (Color)arrayListRGB[beginIndex + i];
		}

		mesh.vertices = points;
		mesh.colors = colors;
		mesh.SetIndices(indecies, MeshTopology.Points, 0);

	}

	private void readLungDataFromFile() {
		Debug.Log("xy ==> 1.1 readLungDataFromFile");

		// 1. 读取数据
		// 提前将点云存成txt文件放在Assert/StreamingAssets文件夹下，文本的每行代表一个点，由点的x，y，z，r，g，b六个float组成
		string fileAddress = (Application.streamingAssetsPath + "/" + "lung.txt");
		FileInfo fInfo0 = new FileInfo(fileAddress);
		Debug.Log(fileAddress);

		string s = "";
		StreamReader r;
		arrayListXYZ = new ArrayList();
		arrayListRGB = new ArrayList();

		if (fInfo0.Exists) {
			Debug.Log ("xy ==> readLungDataFromFile Exists");
			r = new StreamReader (fileAddress);
		} else {
			Debug.Log ("No such file!");
			return;
		}

		while((s = r.ReadLine()) != null) {
			Debug.Log ("[ReadLine]: " + s);

			string[] words = s.Split(" "[0]);
			Debug.Log ("[ReadLine words]: " + words[0]);
			Debug.Log ("[ReadLine words]: " + words[1]);
			Debug.Log ("[ReadLine words]: " + words[2]);
			Debug.Log ("[ReadLine words]: " + words[3]);

			Vector3 xyz = new Vector3(float.Parse(words[1]), -float.Parse(words[2]), float.Parse(words[3]));
			arrayListXYZ.Add(xyz);
//			Color colorRGB = new Color(float.Parse(words[3]) / 255.0f, float.Parse(words[4]) / 255.0f, float.Parse(words[5]) / 255.0f);
			// 30 145 170
			Color colorRGB = new Color(30.0f / 255.0f, 145.0f / 255.0f, 170.0f / 255.0f);
			arrayListRGB.Add(colorRGB);
			Debug.Log("xy readLungDataFromFile: " + xyz.ToString() + ", " + colorRGB.ToString());
		}
		//		Debug.Log("xy readLungDataFromFile arrayListXYZ size: " + arrayListXYZ.Count);
		//		Debug.Log("xy readLungDataFromFile arrayListRGB size: " + arrayListRGB.Count);
	}

	private void readCubeDataFromFile() {
		Debug.Log("xy ==> 1.1 readCubeDataFromFile");

		// 1. 读取数据
		// 提前将点云存成txt文件放在Assert/StreamingAssets文件夹下，文本的每行代表一个点，由点的x，y，z，r，g，b六个float组成
		string fileAddress = (Application.streamingAssetsPath + "/" + "test0.txt");
		FileInfo fInfo0 = new FileInfo(fileAddress);
		Debug.Log(fileAddress);

		string s = "";
		StreamReader r;
		arrayListXYZ = new ArrayList();
		arrayListRGB = new ArrayList();

		if (fInfo0.Exists) {
			Debug.Log ("xy ==> readCubeDataFromFile Exists");
			r = new StreamReader (fileAddress);
		} else {
			Debug.Log ("No such file!");
			return;
		}

		while((s = r.ReadLine()) != null) {

			string[] words = s.Split(" "[0]);

			Vector3 xyz = new Vector3(float.Parse(words[0]), -float.Parse(words[1]), float.Parse(words[2]));
			arrayListXYZ.Add(xyz);
			Color colorRGB = new Color(float.Parse(words[3]) / 255.0f, float.Parse(words[4]) / 255.0f, float.Parse(words[5]) / 255.0f);
			arrayListRGB.Add(colorRGB);
			Debug.Log("xy readCubeDataFromFile: " + xyz.ToString() + ", " + colorRGB.ToString());
		}
		//		Debug.Log("xy readCubeDataFromFile arrayListXYZ size: " + arrayListXYZ.Count);
		//		Debug.Log("xy readCubeDataFromFile arrayListRGB size: " + arrayListRGB.Count);
	}

	void OnGUI()  
	{  

		if(GUILayout.Button("Left"))  
		{  
			//通过tag值找到相应的对象  
			GameObject obj2 = GameObject.FindGameObjectWithTag("shui");  

			obj2.transform.Rotate(new Vector3(0,10,0));  
			//让该物体转动参数的意义（x,y,z）就是沿着哪个轴转动  

		}  
		if(GUILayout.Button("UP"))  
		{  
			GameObject obj3 = GameObject.FindGameObjectWithTag("shui");  
			//参数（x，y，z）y为正向上其他的自己猜猜吧  
			obj3.transform.Translate(new Vector3(0,3* Time.deltaTime,0));  

		}  
	}

	// Update is called once per frame
	void Update () {
//		GameObject obj4 = GameObject.FindGameObjectWithTag("shui");
//		GUILayout.Label ("position" + obj4.transform.position);
	}

	//	private void readData() {
	//		Debug.Log("xy ==> 1.0 readData");
	//
	//		//		0 0 0 0 30 145 170
	//		//		0 0 1 0 30 145 170
	//		//		0 1 1 0 30 145 170
	//		//		0 1 0 0 30 145 170
	//		//		1 0 0 0 30 145 170
	//		//		1 0 1 0 30 145 170
	//		//		1 1 1 0 30 145 170
	//		//		1 1 0 0 30 145 170
	//		xyz = new Vector3(0, 0, 0);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//
	//		xyz = new Vector3(0, 0, 0.3f);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//
	//		xyz = new Vector3(0, 0, 0.5f);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//
	//		xyz = new Vector3(0, 0, 0.8f);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//
	//		xyz = new Vector3(0, 0, 1);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//
	//		xyz = new Vector3(0, 1, 1);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//
	//		xyz = new Vector3(0, 1, 0);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//
	//		xyz = new Vector3(1, 0, 0);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//
	//		xyz = new Vector3(1, 0, 1);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//
	//		xyz = new Vector3(1, 0.3f, 1);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//
	//		xyz = new Vector3(1, 0.5f, 1);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//
	//		xyz = new Vector3(1, 0.8f, 1);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//
	//		xyz = new Vector3(1, 1, 1);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//
	//		xyz = new Vector3(1, 1, 0.7f);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//
	//		xyz = new Vector3(1, 1, 0.5f);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//
	//		xyz = new Vector3(1, 1, 0.3f);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//
	//		xyz = new Vector3(1, 1, 0);
	//		arrayListXYZ.Add(xyz);
	//		colorRGB = new Color(30f / 255.0f, 145 / 255.0f, 170 / 255.0f);
	//		arrayListRGB.Add(colorRGB);
	//		Debug.Log("xy debug: " + xyz.ToString() + "," + colorRGB.ToString());
	//		Debug.Log("xy debug: " + arrayListXYZ.Count + "," + arrayListRGB.Count);
	//	}
}
