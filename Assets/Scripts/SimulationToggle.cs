using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SimulationToggle : MonoBehaviour 
{	
	// Use this for initialization
	void Start () 
	{	
		Paddle.isSimulation = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void OnValueChanged()
	{
		Paddle.isSimulation = !Paddle.isSimulation;
	}
}