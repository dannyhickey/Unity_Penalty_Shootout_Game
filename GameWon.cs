using UnityEngine;
using System.Collections;

public class GameWon : MonoBehaviour {


		void Update()
		{

		if(Input.GetMouseButtonDown(0))
		 
			{
			Debug.Log("Pressed left click.");
				Application.LoadLevel(0);
			}
		}


	
}