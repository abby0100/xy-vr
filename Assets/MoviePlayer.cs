using UnityEngine;
using UnityEngine.UI;

public class MoviePlayer : MonoBehaviour
{

	public Image image;
	public MovieTexture movie;
	public AudioSource audioPlayer;

	void Awake()
	{
		image.material.mainTexture = movie;
		Play();
	}

	public void Play()
	{
		movie.Play();
		audioPlayer.Play();
	}

	public void Stop()
	{
		movie.Stop();
		audioPlayer.Stop();
	}

	public void Pause()
	{
		movie.Pause();
		audioPlayer.Pause();
	}
}