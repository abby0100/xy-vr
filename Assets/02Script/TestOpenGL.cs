using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOpenGL : MonoBehaviour {

	public Material material;

	void Awake() {}

	void OnPostRender() {
		Debug.Log ("OnPostRender");

		GL.Clear (true, true, Color.grey);
		GL.PushMatrix ();

		// 设置绘制模式为2D绘制，设置这个模式之后屏幕左下角变为(0,0)，屏幕右上角变为(1,1)，注释之后变为3D真实坐标
		GL.LoadOrtho ();

		for (var i = 0; i < material.passCount; ++i) {
			
			material.SetPass (i);
			GL.Begin (GL.LINES);
			GL.Color (Color.red);
			GL.Vertex3 (0.1F, 0.1F, 0);
			GL.Vertex3 (0.2F, 0.2F, 0F);

			GL.Color (Color.white);
			GL.Vertex3 (0.2F, 0.2F, 0F);
			GL.Color (Color.white);
			GL.Vertex3 (0.3F, 0.1F, 0);

			GL.Color (Color.blue);
			GL.Vertex3 (0.3F, 0.1F, 0);
			GL.Color (Color.blue);
			GL.Vertex3 (0.1F, 0.1F, 0);

			GL.End ();
		}

		GL.PopMatrix ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
