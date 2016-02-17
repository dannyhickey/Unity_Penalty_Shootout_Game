using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour {

	public float fullWidth = 256; //max width of the powerbar
	public float thePower; //current power
	public bool increase = false; 
	public static bool kicking = false;
	public float barSpeed = 400; //how fast bar will fill in.
	public GameObject ball; //ball gameobject
	public bool keyTime = true;
	public static float bang;


	// Use this for initialization
	void Start () {

		ball = GameObject.Find("Ball"); //finding ball gameobject Ball to make it move.
	}


	// Update is called once per frame
	void Update () {
		//Debug.Log("The speed is: " + Shoot.speed);
		if(!kicking)
		{
			if(Input.GetKeyDown(KeyCode.Space)) { //if shoot button is held down set increase to true.
				increase = true;



			}
			else if(Input.GetKeyUp(KeyCode.Space) && keyTime == true) {
				ball.rigidbody.AddForce (Vector3.up * Shoot.speed  * 5); //Adding force to the ball.
			
				increase = false; //set bar increasing back to false.
				//placing the speed value in the bang variable to be used in the shoot.cs
				//It is used in the Shoot.cs to detect if there is enough power for explosion effect. 
				bang = Shoot.speed;

				kicking = true;

			}
		}

		Rect pos = guiTexture.pixelInset;
		pos.xMax = guiTexture.pixelInset.xMin + fullWidth*Shoot.speed /fullWidth *10;
		guiTexture.pixelInset = pos;

		if(increase) //if bar is increasing, calculate thepower
		{
			//Debug.Log("The speed is: " + Shoot.speed);

			Shoot.speed += Time.deltaTime * barSpeed;
			Shoot.speed  = Mathf.Clamp (Shoot.speed , 0, fullWidth);

		}
		else //else set the speed back to 0.
		{
			Shoot.speed =0;
		}



		kicking = false;
	
	}

}