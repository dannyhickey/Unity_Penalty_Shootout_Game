using System;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
	public static float timeLeft;
	public float tim;

	public void Start()
	{
		checkTime();

	}
	
	public void Update()
	{
		timeLeft -= Time.deltaTime;

		// Checking to see if player has enough goals before the time is up
		if (timeLeft <= 3.0f && Shoot.score < 4)
		{
			// End the level here.
			guiText.text = "Hurry!! You are running out of time!! 3 seconds remaining  !!!";
		}else
			guiText.text = "Time left = " + (int)timeLeft + " seconds"; //casting timeLeft to integer

		// Making sure the time doesn't keep counting down if player has 4 goals
		if(timeLeft <= 0.0f)
		{
			Debug.Log("Time Up");
			//load the game over screen when time has run out
			Application.LoadLevel(3);
		}


		
		
	}


	//Function checks which level the game is in and sets the remaining start time for
	//the respective level to achieve an increase in difficulty.
	public static void checkTime()
	{
		if (Shoot.level == 1)
		{
			timeLeft = 120.0f;
			timeLeft -= Time.deltaTime;
		}

	}	
}