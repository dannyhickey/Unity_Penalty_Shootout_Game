using UnityEngine;
using System.Collections;

public class GoalkeeperController : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	public void Dive()
	{
		int direction = (int) Random.Range(1,4);

		Debug.Log("Direction is: " + direction);
		switch(direction)
		{
		case 1:
			anim.SetTrigger("Left");
			break;
		case 2:
			anim.SetTrigger("Right");
			break;
		case 3:
			;
			break;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if(Shoot.getInGoal == true)
		{
			reposition();
		}
	}

	void reposition()
	{
		//Setting the position of the goalkeeper to the centre of the goal
		
		transform.position = new Vector3(3.2f,0.2f,32f);
	}
}
