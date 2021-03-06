﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour 
{
	// Public Variables
	#region
	public Sprite[] damageSprites;
	public static int numBreakableBricks = 0;
	public AudioClip hitSound;
	public AudioClip destroySound;
	public GameObject particleEmission;
	public static float sfxVolume = 1.0f;
	#endregion
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () 
	{
		timesHit = 0;
		levelManager = FindObjectOfType<LevelManager>();
		isBreakable = (this.tag == "Breakable");
		sfxVolume = MusicPlayer.sfxVolume;
								
		// Keep track of breakable objects 
		if (isBreakable)
		{
			++numBreakableBricks;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//OnCollisionEnter2D();
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{				
		if (isBreakable)
		{
			HandleHits();
		}
		
		else
		{
			AudioSource.PlayClipAtPoint( hitSound, transform.position, sfxVolume);
		}
	}
	
	void HandleHits()
	{
		++timesHit;
		
		//maximum no. of hits is damageSprites.Length + 1.
		//TODO Emit particle from bricks
				
		if (timesHit >= (damageSprites.Length + 1))
		{
			GameObject particleColor = Instantiate(particleEmission, gameObject.transform.position, Quaternion.identity) as GameObject;
			particleColor.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			AudioSource.PlayClipAtPoint( destroySound, transform.position, sfxVolume);
			--numBreakableBricks;
			levelManager.BrickDestroyed();
			Destroy(gameObject);	
		}
		
		else
		{
			AudioSource.PlayClipAtPoint( hitSound, transform.position, sfxVolume);
			LoadSprites();
		}
		
		print ("Bricks Left: " + numBreakableBricks);
	}
	
	void LoadSprites()
	{
		//int spriteIndex = timesHit - 1;
				
		//To guard if any of the sprites is not supplied
		if (damageSprites[timesHit - 1])
		{
			this.GetComponent<SpriteRenderer>().sprite = damageSprites[timesHit - 1];
		}
	}
}