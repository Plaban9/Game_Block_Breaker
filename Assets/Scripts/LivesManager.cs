using UnityEngine;
using System.Collections;

public class LivesManager : MonoBehaviour 
{
	// Public Variables
	#region
	public Sprite[] livesSprite;
	#endregion
	
	
	// Use this for initialization
	void Start () 
	{
		this.GetComponent<SpriteRenderer>().sprite = livesSprite[0];
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.GetComponent<SpriteRenderer>().sprite = livesSprite[livesSprite.Length - LoseCollider.lifeCounter];
	}
}
