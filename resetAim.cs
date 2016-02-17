using UnityEngine;
using System.Collections;

public class resetAim : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//Starts the position of the "Aim" object at centre of the goal 
		transform.position = new Vector3(2.6f,2.8f,32);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if the aimCanMove boolean is activated to true in the Shoot.cs
		if(Shoot.aimCanMove == true)
		{
			//set the position of the "Aim" object back to the centre of the goal 
			transform.position = new Vector3(2.6f,2.8f,32);
			Shoot.aimCanMove = false;
		}
	
	}
}
  