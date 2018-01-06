using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour 
{
	// Public Variables
	#region
	public AudioClip hitSound;
	public static float sfxVolume = 1.0f;
	#endregion
	
	// Use this for initialization
	void Start () 
	{
		sfxVolume = MusicPlayer.sfxVolume;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnCollisionEnter2D(Collision2D collisison)
	{
		AudioSource.PlayClipAtPoint( hitSound, transform.position, sfxVolume);
	}
}