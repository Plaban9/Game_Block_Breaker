using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour 
{
	// Public variables
	#region
	public static byte lifeCounter = 3;
	public AudioClip destroySound;
	public AudioClip gameOverSound;
	public static float sfxVolume = 1.0f;
	#endregion
	
	private LevelManager levelManager;
	private Ball ball;
	
	void Start()
	{
		ball = FindObjectOfType<Ball>();
		sfxVolume = MusicPlayer.sfxVolume;
	}							
			
	void OnTriggerEnter2D (Collider2D triggerObject)
	{
        if (triggerObject.CompareTag("Bullet") || triggerObject.CompareTag("PowerUp"))
        {
            Destroy(triggerObject.gameObject);
			return;
        }

        //if (triggerObject.CompareTag("PowerUp"))
        //{
        //    Destroy(triggerObject.gameObject);
        //    return;
        //}

        if (lifeCounter > 1)
		{
			AudioSource.PlayClipAtPoint( destroySound, transform.position, sfxVolume);
			--lifeCounter;
			ball.BallSpriteChanger();
			ball.ResetPosition();
		}
		
		else
		{
			AudioSource.PlayClipAtPoint( gameOverSound, transform.position, sfxVolume);
			lifeCounter = 3;
			levelManager = FindObjectOfType<LevelManager>();
			levelManager.LoadLevel("Lose");
		}
	}
	
	void OnCollisionEnter2D (Collision2D collisionObject)
	{
		print ("Collisiion");
	}
}