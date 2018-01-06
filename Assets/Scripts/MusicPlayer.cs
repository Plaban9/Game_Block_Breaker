using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
	//To not create duplicate music player and to prevent a click sound during loading a scene (solution - put in awake)
	static MusicPlayer instance = null;
	public static float musicVolume = 0.25f;
	public static float sfxVolume = 1.0f;
	
	void Awake()
	{
		Debug.Log("Music Player Awake " + GetInstanceID());
		
		if (instance != null)
		{
			Destroy(gameObject);
			print("Duplicate Music Player Destroyed");
		}
		
		else
		{
			instance = this;		
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	// Use this for initialization
	void Start () 
	{
		Debug.Log("Music Player Start " + GetInstanceID());
		gameObject.audio.volume = musicVolume;
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.audio.volume = musicVolume;
	}
}