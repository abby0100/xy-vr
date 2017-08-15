using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeshMeshCurve : MonoBehaviour {

	private string LOG_TAG = "[TeshMeshCurve] ";

	public Material material;
	public int segments = 20;
	public int innerRadium = 5;
	public int radium = 10;
	public Vector3 circleCenter = new Vector3 (0, 0, 0);

	// Use this for initialization
	void Start () {

//		TestVector ();
//		DrawTriangle ();
//		DrawSquare ();
		DrawCircle (radium);
//		DrawRing(innerRadium, radium);

	}


	void DrawCircle (int circleRadium) {

		MeshFilter filter = gameObject.AddComponent<MeshFilter> ();
		MeshRenderer renderer = gameObject.AddComponent<MeshRenderer> ();
		renderer.material = material;

		Mesh mesh = filter.mesh;
		mesh.Clear();

		float deltaAngle = Mathf.Deg2Rad * 360f / segments;
		float currentAngle = 0;

		Vector3[] vertices = new Vector3[segments + 1];
		int[] triangles = new int[segments * 3];
	
		for (int i = 1; i <= segments; i++) {
			float cosA = Mathf.Cos (currentAngle);
			float SinA = Mathf.Sin (currentAngle);
			vertices [i] = new Vector3 (circleCenter.x + cosA * circleRadium,circleCenter.y + SinA * circleRadium,circleCenter.z);

			currentAngle += deltaAngle;
		}
		vertices [0] = circleCenter;

		for(int i = 0; i < segments - 1; i++) {
			triangles [3 * i] = 0;
			if (i % 2 == 0) {
				triangles [3 * i + 1] = i+1;
				triangles [3 * i + 2] = i+2;
			} else {
				triangles [3 * i + 1] = i+2;
				triangles [3 * i + 2] = i+1;
			}
		}
		triangles [3 * segments - 3] = 0;
		triangles [3 * segments - 2] = 1;
		triangles [3 * segments - 1] = segments;

		mesh.vertices = vertices;
		mesh.triangles = triangles;
	}

	void DrawSquare () {

		MeshFilter filter = gameObject.AddComponent<MeshFilter> ();
		MeshRenderer renderer = gameObject.AddComponent<MeshRenderer> ();
		renderer.material = material;

		Mesh mesh = filter.mesh;
		mesh.Clear();

		mesh.vertices = new Vector3[] {
			new Vector3(0, 0, 0),	
			new Vector3(0, 1, 0),	
			new Vector3(1, 1, 0),	
			new Vector3(1, 0, 0),	
		};
		mesh.triangles = new int[]{ 
			0, 1, 2,
			0, 2, 3,
		};
	}

	void DrawTriangle () {

		MeshFilter filter = gameObject.AddComponent<MeshFilter> ();
		MeshRenderer renderer = gameObject.AddComponent<MeshRenderer> ();
		renderer.material = material;

		Mesh mesh = filter.mesh;
		mesh.Clear();

		mesh.vertices = new Vector3[] {
			new Vector3(0, 0, 0),	
			new Vector3(0, 1, 0),	
			new Vector3(1, 1, 0),	
		};
		mesh.triangles = new int[]{ 0, 1, 2 };
	}

	void TestVector() {
		Vector3 v = new Vector3(1, 2, 3);
		Debug.Log (LOG_TAG + "test Vector3: " + v.x);
		Debug.Log (LOG_TAG + "test Vector3: " + v.y);
		Debug.Log (LOG_TAG + "test Vector3: " + v.z);

		Vector3[] vs = new Vector3[3] {
			new Vector3(1,2,3),
			new Vector3(4,5,6),
			new Vector3(7,8,9),
		};

		vs [1] = new Vector3 (7,8,9);

		Debug.Log (LOG_TAG + "test Vector3: " + vs[1].x);
		Debug.Log (LOG_TAG + "test Vector3: " + vs[1].y);
		Debug.Log (LOG_TAG + "test Vector3: " + vs[1].z);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
