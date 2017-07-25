using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class UnityTestDll : MonoBehaviour {

	[DllImport("TestDll")]
	private static extern int add (int x, int y);

	int i = add(5, 7);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {
		GUI.Button (new Rect(1, 1, 200, 100), "this dll i = 5+7, i is " + i);
	}
}
