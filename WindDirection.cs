using UnityEngine;
using System.Collections;


public class WindDirection : MonoBehaviour
{

	public static float windSpeed;
	public float windAlive;

	void Start()
	{
		//starts the scene by giving the wind variable a random range between -2 and 2.
		windAlive = Random.Range(-5.0f, 5.0f);
	}
		void FixedUpdate() {
			//In this fixed update I use the AddForce to add
			//my windspeed value randomly generated above to add 
			//a constant force to the z axis of my ball

			rigidbody.AddForce(0, 0, windSpeed);

	}

	void Update()
	{	
		//Wind is only active if you make it above level 2
		if (Shoot.level > 2)
		{
			windSpeed = windAlive;
			//transform.GetComponent<Cloth>().stretchingStiffness = 1;

		}
	}
	
}
