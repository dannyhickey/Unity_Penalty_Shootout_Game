using UnityEngine;
using System.Collections;

public class orbitCam : MonoBehaviour {

	public GameObject target = null;
	public bool orbitY = false;
	public int orbitSpeed = 30;//the speed at which it moves

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(target!=null)
		{
			transform.LookAt(target.transform);//look at the GameObject stadium

			if(orbitY)
			{   //rotates around the stadium using Vector3.up 
				transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * orbitSpeed);
			}
		}
	}
}
