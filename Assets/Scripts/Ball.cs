using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	// Public Parameters
	#region
	public AudioClip launchSound;
	public GameObject destroyEmitter;
	public Sprite[] ballSprites;
	public static float sfxVolume = 1.0f;
	#endregion
	
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private float launchY;
	private bool hasStarted = false;
		
	// Use this for initialization
	void Start () 
	{
		paddle = FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		launchY = paddleToBallVector[1];
		sfxVolume = MusicPlayer.sfxVolume;
	}

	// Update is called once per frame
	void Update () 
	{			
		// To Lock the ball relative to the paddle
		if (!hasStarted)
		{	
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			// Wait for a mouse left click to launch
			if (Input.GetMouseButtonDown(0))
			{
				shootBall();
				hasStarted = true;	
			}
		}
	}
		
	void shootBall()
	{
		// Shoot the ball relative to mouse position w.r.t ball position
		/*
		if ((this.transform.position.x - Input.mousePosition.x) > 0)
		{
			this.rigidbody2D.velocity = new Vector2( 2f, 10f);
		}

		else
		{
			this.rigidbody2D.velocity = new Vector2( -2f, 10f);				
		}			
		*/
		
		// Shoot the ball relative to screen width center w.r.t ball position
		if ( this.transform.position.x < 8)
		{
			this.rigidbody2D.velocity = new Vector2( 2.5f, 10f);
			AudioSource.PlayClipAtPoint( launchSound, transform.position, sfxVolume);
			//print (ballTrajectory);
		}
		
		else
		{
			this.rigidbody2D.velocity = new Vector2( -2.5f, 10f);
			AudioSource.PlayClipAtPoint( launchSound, transform.position, sfxVolume);
			//audio.Play();
			//print (ballTrajectory);
		}
	}
	
	void OnCollisionEnter2D(Collision2D collisison)
	{
		Vector2 tweakVelocity = new Vector2(Random.Range( -0.2f, 0.2f), Random.Range( 0f, 0.2f));
		rigidbody2D.velocity += tweakVelocity;
		this.transform.Rotate( 0f, 0f, Random.Range( 35f, 45f));		
	}
	
	void OnTriggerEnter2D (Collider2D triggerObject)
	{
		Instantiate( destroyEmitter, gameObject.transform.position, Quaternion.identity);
		/*GameObject destroyColor = Instantiate( destroyEmitter, gameObject.transform.position, Quaternion.identity) as GameObject;
		destroyColor.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;*/
	}
	
	public void BallSpriteChanger()
	{
		if (ballSprites[ballSprites.Length - LoseCollider.lifeCounter])
		{
			this.GetComponent<SpriteRenderer>().sprite = ballSprites[ballSprites.Length - LoseCollider.lifeCounter];
		}
	}
	
	public void ResetPosition()
	{
		Vector3 resetVector = paddleToBallVector;
		resetVector[1] = launchY; 		
		paddleToBallVector = resetVector;
		hasStarted = false;
	}
	
	public bool GetLaunchStatus()
	{
		return hasStarted;
	}
}