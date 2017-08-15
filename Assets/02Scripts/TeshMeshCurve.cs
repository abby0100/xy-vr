using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeshMeshCurve : MonoBehaviour {

	private string LOG_TAG = "[TeshMeshCurve] ";

	public Material material;
	public int segments = 4;
	public int innerRadium = 5;
	public int radium = 10;
	public Vector3 circleCenter = new Vector3 (0, 0, 0);

	// Use this for initialization
	void Start () {

//		TestVector ();
//		DrawTriangle ();
//		DrawSquare ();
//		DrawCircle (radium);
		DrawRing(innerRadium, radium);

	}

	void DrawRing (int innerRadio, int outerRadio) {
		Debug.Log (LOG_TAG + "DrawRing innerRadio " + innerRadio + ", outerRadio " + outerRadio);

		MeshFilter filter = gameObject.AddComponent<MeshFilter> ();
		MeshRenderer renderer = gameObject.AddComponent<MeshRenderer> ();
		renderer.material = material;

		Mesh mesh = filter.mesh;
		mesh.Clear();

		float deltaAngle = Mathf.Deg2Rad * 360f / segments;
		float currentAngle = 0;

		Vector3[] vertices = new Vector3[segments * 2];
		for (int i = 0; i < segments; i++) {
			float cosA = Mathf.Cos (currentAngle);
			float SinA = Mathf.Sin (currentAngle);

			vertices [i * 2] = new Vector3 (circleCenter.x + cosA * innerRadio,circleCenter.y + SinA * innerRadio,circleCenter.z);
			vertices [i * 2 + 1] = new Vector3 (circleCenter.x + cosA * outerRadio,circleCenter.y + SinA * outerRadio,circleCenter.z);
			currentAngle += deltaAngle;
		}

		int[] triangles = new int[segments * 6];
		for (int i = 0, j = 0; i < segments * 6; i+=6, j+=2) {

			triangles [i] = j;
			triangles [i + 1] = (j+3) % vertices.Length;
			triangles [i + 2] = (j+1) % vertices.Length;

			triangles [i + 3] = j;
			triangles [i + 4] = (j+2) % vertices.Length;
			triangles [i + 5] = (j+3) % vertices.Length;

			Debug.Log (LOG_TAG + "triangles " + (i) + ": " + triangles [i + 0]);
			Debug.Log (LOG_TAG + "triangles " + (i) + ": " + triangles [i + 1]);
			Debug.Log (LOG_TAG + "triangles " + (i) + ": " + triangles [i + 2]);
			Debug.Log (LOG_TAG + "triangles " + (i) + ": " + triangles [i + 3]);
			Debug.Log (LOG_TAG + "triangles " + (i) + ": " + triangles [i + 4]);
			Debug.Log (LOG_TAG + "triangles " + (i) + ": " + triangles [i + 5]);


//			triangles [i * 6] = 2 * i;
//			triangles [i * 6 + 2] = 2 * i + 1;
//			triangles [i * 6 + 1] = 2 * i + 3;
//
//			triangles [i * 6 + 3] = 2 * i;
//			triangles [i * 6 + 5] = 2 * i + 3;
//			triangles [i * 6 + 4] = 2 * i + 2;
//
//			Debug.Log (LOG_TAG + "triangles " + (i * 6 + 0) + ": " + triangles [i * 6 + 0]);
//			Debug.Log (LOG_TAG + "triangles " + (i * 6 + 1) + ": " + triangles [i * 6 + 1]);
//			Debug.Log (LOG_TAG + "triangles " + (i * 6 + 2) + ": " + triangles [i * 6 + 2]);
//			Debug.Log (LOG_TAG + "triangles " + (i * 6 + 3) + ": " + triangles [i * 6 + 3]);
//			Debug.Log (LOG_TAG + "triangles " + (i * 6 + 4) + ": " + triangles [i * 6 + 4]);
//			Debug.Log (LOG_TAG + "triangles " + (i * 6 + 5) + ": " + triangles [i * 6 + 5]);
		}

		mesh.vertices = vertices;
		mesh.triangles = triangles;
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
