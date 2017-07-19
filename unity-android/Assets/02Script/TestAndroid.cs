using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAndroid : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		if(GUILayout.Button("OPEN Unity-Android",GUILayout.Height(100)))
		{
			//注释1
			AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
			jo.Call("testUnityAndroid","");
		}

	}
}
