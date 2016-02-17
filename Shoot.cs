using UnityEngine;
using System.Collections;


// Added to 'Ball' game object
public class Shoot : MonoBehaviour
{
	// Reference to the "Aim" Object
	public GameObject aim;
	bool shooting;
	public static bool getInGoal;//boolean to help decide when to reposition the goalkeeper 
	public static bool aimCanMove;//boolean to help decide when to reposition the "Aim" 

	public static float speed = 5;//speed of the shot
	public static int score;//integer variable to store how many goals have been scored
	public int attempts;// integer variable to store the number of attempts remaining
	public GUIText guiScore;//GUIText to display the score

	public static int level;
	public GUIText guiLevel;

	public GUIText guiGoal;//Goal Display Text
	public GUIText guiMiss;//Miss Display Text

	public GUIText guiWindSpeed;//GUIText to display the windspeed
	public GUIText guiAttemptsLeft;//GUIText to display the remaining attempts

	public AudioClip goal; //variable to hold sound for goal
	bool goalSound;



	public AudioClip miss; //variable to hold sound for miss
	bool missSound;

	public AudioClip post; //variable to hold sound for post being hit
	bool postSound;

	public AudioClip boom;
	bool boomSound;

	public AudioClip kick; //variable to hold sound for ball kick
	bool kickSound;

	public GameObject explode;

	public GUITexture levelTwo; //used to display instructions to the next level 2
	public GUITexture levelThree; //used to display instructions to the next level 3
	public GUITexture levelFour; //used to display instructions to the next level 4


	public ParticleSystem raining;//variable to allow control of which level it rains in. 



	public void Start ()
	{
		levelTwo.enabled = false;
		levelThree.enabled = false;
		levelFour.enabled = false;

		goalSound = false;
		missSound = false;
		postSound = false;
		kickSound = false;
		aimCanMove = true;
		boomSound = false;
		raining.Stop();



		guiScore.text = "Score: 0";
		guiLevel.text = "Level: 1";
		guiAttemptsLeft.text = "Attempts Left: 5";
		guiWindSpeed.text = "Wind Speed: ";
		score = 0;
		attempts = 5;
		level = 1;

		shooting = false;
		//positionTheBall();
		rigidbody.freezeRotation = true;
		rigidbody.velocity = new Vector3 (0,0,0);//Starting position


		guiGoal.text = "";
		guiMiss.text = "";

	}


	
	public void positionTheBall()
	{
	


		rigidbody.velocity = Vector3.zero;
		//Setting the position of the ball on my penalty spot
		transform.position = new Vector3(Random.Range(15.0F, 20.0F),0.5f,Random.Range(15.0F, 50.0F));
		//freeze the rotation of the ball when repositioned to stop the wind from moving it at the
		//beginning of every penalty/shot. 
		rigidbody.freezeRotation = true;





		//Vector3(Random.Range(-10.0F, 10.0F), 1, Random.Range(-10.0F, 10.0F));
		//rigidbody.constantForce.force = Vector3.zero;
	}
	
	IEnumerator ShootBall()
	{	
		//Changes the static boolean in 
		//CameraSwitch.cs to false in order
		//to switch the camera following the ball
		CameraSwitch.isSecondary = false;
		//It was necessary to deactivate the freeze rotation 
		//that was set to true in the positionTheBall() method above. 
		rigidbody.freezeRotation = false;


		getInGoal = false;
		shooting = true;
		Vector3 direction = aim.transform.position - transform.position;
		direction = direction.normalized;		
		rigidbody.AddForce(direction * speed, ForceMode.Impulse);
		GameObject.FindGameObjectWithTag("Goalkeeper").GetComponent<GoalkeeperController>().Dive();
		attempts--;
		guiAttemptsLeft.text = "Attempts Left: " + attempts;

		//waits five seconds before you can use the above statements again
		yield return new WaitForSeconds(3);

	


		//changes back to the default cam
		CameraSwitch.isSecondary = true;
		
		getInGoal = true;
		aimCanMove = true;

		//making sure to set the shooting boolean back to false so we can shoot again.
		shooting = false;
		guiGoal.text = "";
		guiMiss.text = "";
		positionTheBall();



		//Game over when no attempts left and score is less than 4
		if(attempts < 1 && score < 4)
		{
			Application.LoadLevel(3);
		}

		//Through to the next round when no attempts left and player achieves a score of 4 or more
		if (attempts <= 1 && score > 3)
		{
			level++;//level increases when you achieve the above condition
			//each if statement checks what level it's on and then carries out the 
			//statement depending on the level.		
			if(level == 2)
			{
				
				rigidbody.velocity = new Vector3 (0,0,0);//Ensures the first kick of the level is on the penalty spot
				guiWindSpeed.enabled = false;
				levelTwo.enabled = true;
			
				score = 0;
				guiScore.text = "Score: " + score;
				attempts = 5;
			
				guiLevel.text = "Level: " + level;

				//actives the rain particles for this level
				raining.Play();

				//in level 2 I have instantiated the rainsound object and the defender cube
				GameObject rainObject = (GameObject)Instantiate(Resources.Load("RainObjectSound"));
				GameObject cubeBlock = (GameObject)Instantiate(Resources.Load("DefenderCube"));

			}

			if(level == 3)
			{
				rigidbody.velocity = new Vector3 (0,0,0);//Ensures the first kick of the level is on the penalty spot
				GameObject windObject = (GameObject)Instantiate(Resources.Load("GameObjectWind"));
				guiWindSpeed.enabled = true;
				levelThree.enabled = true;
				score = 0;
				guiScore.text = "Score: " + score;
				attempts = 5;
				//start the wind here
				//level++;
				guiLevel.text = "Level: " + level;
				//Application.LoadLevel(4);
			}

			if(level == 4)
			{
				rigidbody.velocity = new Vector3 (0,0,0);//Ensures the first kick of the level is on the penalty spot
				guiWindSpeed.enabled = true;
				levelFour.enabled = true;
				score = 0;
				guiScore.text = "Score: " + score;
				attempts = 5;
				GameObject textObject = (GameObject)Instantiate(Resources.Load("Defenders"));
				//level++;
				guiLevel.text = "Level: " + level;

			}

			if(level > 4)
			{
				Application.LoadLevel(4);
			}


		}


	}



	void Update()
	{

		if(Input.GetKeyDown(KeyCode.I))
		{
			levelTwo.enabled = false;
			levelThree.enabled = false;
			levelFour.enabled = false;
		}
		//
		if (Input.GetKeyDown(KeyCode.Escape))
		{	//Escape key quits the game
			Application.Quit();
		}
		if(!shooting && Input.GetKeyUp(KeyCode.Space))
		{
			StartCoroutine(ShootBall());
			kickSound = true; // once the goal is detected above the goalSound is activated 
			if(kickSound = true)// when activated the statement plays the sound once
			{
				audio.PlayOneShot(kick);
				//Debug.Log("Kick Sound Played");
				
			}
		}
		
		if(Input.GetKeyUp(KeyCode.R))
		{
			positionTheBall();


		}
		guiWindSpeed.text = "Wind Speed: " + WindDirection.windSpeed;

		if(level < 2)
		{
		
			guiWindSpeed.enabled = false;
	
		}
	}

	void OnTriggerEnter(Collider triggered) {
		if(triggered.gameObject.name == "GoalDetect")
		{			
				score++;
				guiScore.text = "Score: " + score;

			goalSound = true; // once the goal is detected above the goalSound is activated 
			if(goalSound == true)// when activated the statement plays the sound once
			{
				audio.PlayOneShot(goal);
				//Debug.Log("goal Sound Played");

			}

			guiGoal.text = "Goal!!!";


		}


	

		if(triggered.gameObject.name == "MissDetectLeft" || triggered.gameObject.name == "MissDetectRight" || triggered.gameObject.name == "MissDetectOver")
		{
			missSound = true; // once the miss is detected above the missSound is activated 
			if(missSound == true)// when activated the statement plays the sound once
			{
				audio.PlayOneShot(miss);
				//Debug.Log("Miss Sound Played");
				guiMiss.text = "Miss!!!";
			}

		}

		if(triggered.gameObject.name == "LeftGoalPost" || triggered.gameObject.name == "RightGoalPost" || triggered.gameObject.name == "CrossBar")
		{
			postSound = true; // once the post is detected above the postSound is activated 
			if(postSound == true)// when activated the statement plays the sound once
			{
				audio.PlayOneShot(post);
				//Debug.Log("Post Sound Played");				
			}

			//Explosion when ball collides with the goalposts with the shot power greater than 35
			if(Power.bang > 35)
			{
				Instantiate(explode, transform.position, transform.rotation);
				boomSound = true;
				if(boomSound == true)
				{
					audio.PlayOneShot(boom);

				}
			}
			
		}

	}



}