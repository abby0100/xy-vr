using UnityEngine;  
using System.Collections;  
using UnityEngine.Audio;  
using UnityEngine.UI;  
public class MoviePlayer : MonoBehaviour {  
	public MovieTexture movieTexture;  

	// Use this for initialization  
	void Start () {  
		
		StartCoroutine(DownloadMovie()); 

		movieTexture.Play();  
	}    

	IEnumerator DownloadMovie()  
	{

		//WWW www = new WWW("file:///D://Project//Movie/Data/Movie//movie.ogv");  
//		movietexture，只能播放OGG和OVG，而且质量比较低．如果要转成高质量的视频，文件尺寸比较大．　放弃，继续找．
//		WWW www = new WWW("file:///D://test/itflexires.mp4");
		WWW www = new WWW("file:///D://test/movie.ogg");

		Debug.Log(Time.time);  
		movieTexture = www.GetMovieTexture();  

		Debug.Log ("DownloadMovie movieTexture is null ? " + (movieTexture.ToString()));
		GetComponent<Renderer>().material.mainTexture = movieTexture;  
		movieTexture.loop = true; 
		yield return www; 
	}  
		

	void OnGUI()  
	{  
		if (GUILayout.Button("播放/继续"))  
		{  
			//播放/继续播放视频      
			if (!movieTexture.isPlaying)  
			{  
				movieTexture.Play();  
				// audio.Play();  
			}  
		}  

		if (GUILayout.Button("暂停播放"))  
		{  
			//暂停播放      
			movieTexture.Pause();  
			// audio.Pause();  
		}  

		if (GUILayout.Button("停止播放"))  
		{  
			//停止播放      
			movieTexture.Stop();  
			// audio.Stop();  
		}  
	}  
}  