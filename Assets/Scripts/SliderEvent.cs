using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Managers.Audio;

public class SliderEvent : MonoBehaviour 
{
	// Public Variables
	#region
	public Slider musicSlider;
	public Slider sfxSlider;
	#endregion
	
	// Use this for initialization
	void Start () 
	{	
		GameObject.DontDestroyOnLoad(gameObject);
		musicSlider.value = MusicPlayer.musicVolume;
		sfxSlider.value = MusicPlayer.sfxVolume;
		GameObject.DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		SetSFXVolume();
		SetMusicVolume();
	}
	
	void SetSFXVolume()
	{
		if (sfxSlider == null)
		{
			return;
		}
		
		MusicPlayer.sfxVolume = sfxSlider.value;
		}
	
	void SetMusicVolume()
	{
		if (musicSlider == null)
		{
			return;
		}
		
		MusicPlayer.musicVolume = musicSlider.value;
        MusicManager.Instance.MaxVolume = musicSlider.value;

    }
}
