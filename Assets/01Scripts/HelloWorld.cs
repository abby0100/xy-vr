using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log ("Update");
	}

	void OnGUI() {
//		Debug.Log ("OnGUI");

		GUI.skin.label.fontSize = 40;
		GUI.Label (new Rect(10, 10, Screen.width, Screen.height), "Hello Unity World xy!");

		if (GUI.Button(new Rect(0, 10, 100, 40), "xyjoin")) {
			print ("Button print");
		}
	}
}
