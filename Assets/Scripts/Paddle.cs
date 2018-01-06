using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

	// Public Variables
	#region
	public float minX = 0.5f;
	public float maxX = 15.5f;
	public static bool isSimulation;
	public AudioClip hitSound;
	public static float sfxVolume = 1.0f;
	#endregion
	
	// For Testing and Simulation
	private Ball ball = null;
	
	private	float mousePositionX;
	private Vector3 paddlePosition;
		
	// Use this for initialization
	void Start () 
	{
		//paddlePosition = this.transform.position;
		ball = GameObject.FindObjectOfType<Ball>();
		sfxVolume = MusicPlayer.sfxVolume;
	}
	
	// Update is called once per frame
	void Update () 
	{
		mousePositionX = ( Input.mousePosition.x / Screen.width) * 16;
		
		if (isSimulation)
		{
			// For Testing
			MoveWithBall();
		}
		
		else
		{
			MoveWithMouse();
		}
	}
	
	void MoveWithMouse()
	{
		paddlePosition.Set ( Mathf.Clamp (mousePositionX, minX, maxX), this.transform.position.y, this.transform.position.z);
		this.transform.position	= paddlePosition;
	}
	
	void MoveWithBall()
	{
		paddlePosition.Set ( Mathf.Clamp (ball.transform.position.x, minX, maxX), this.transform.position.y, this.transform.position.z);
		this.transform.position	= paddlePosition;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (ball.GetLaunchStatus())
		{
			AudioSource.PlayClipAtPoint( hitSound, transform.position, sfxVolume);
		}
	}
}