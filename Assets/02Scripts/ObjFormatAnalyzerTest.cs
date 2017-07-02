using UnityEngine;
using System.Collections;
using Hont;

//http://www.w2bc.com/article/105389

public class ObjFormatAnalyzerTest : MonoBehaviour
{
    void Start()
    {
		Debug.Log ("Start");
//		var go = ObjFormatAnalyzerFactory.AnalyzeToGameObject(@"D:\test\centaur.obj");
//		WWW www = new WWW("file:/D:/test/texture.jpg");

		var go = ObjFormatAnalyzerFactory.AnalyzeToGameObject(Application.streamingAssetsPath + "/" + "centaur.obj");
		WWW www = new WWW("file:" + Application.streamingAssetsPath + "/" + "texture.jpg");

        while (!www.isDone) { }
//		Debug.Log ("Start texture: " + (www.texture != null));
        go.GetComponent<MeshRenderer>().material.mainTexture = www.texture;
    }
}