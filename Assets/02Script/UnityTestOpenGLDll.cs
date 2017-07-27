using UnityEngine;  
using System.Collections;  
using System.Runtime.InteropServices;  

public class UnityTestOpenGLDll : MonoBehaviour {  

	[DllImport("OpenGLDll")]  
	private static extern int add( int x, int y );  

	int i = add( 5, 7 );  

	// Use this for initialization  
	void Start () {  

	}  

	// Update is called once per frame  
	void Update () {  

	}  

	void OnGUI()  
	{  
		GUI.Button( new Rect( 1, 1, 200, 100 ), "UnityTestDll i = 5+7, i is" + i );  
	}  
}  