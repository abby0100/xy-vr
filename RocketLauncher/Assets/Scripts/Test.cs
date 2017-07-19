using UnityEngine;
using System.Collections;


public class Test : MonoBehaviour {

	void Start()
	{
		AndroidManager.GetInstance();
	}

	public void OnClickButton()
	{
		Debug.Log ("OnClickButton Go");
		AndroidManager.GetInstance().CallJavaFunc( "javaTestFunc", "UnityJavaJarTest" );
		Debug.Log ("Go");
	}

}
