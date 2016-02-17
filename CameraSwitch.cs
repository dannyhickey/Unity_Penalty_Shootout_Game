using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

	public static bool isSecondary;
	public GameObject mainCamera;
	public GameObject secondCamera;

	// Use this for initialization
	void Start () 
	{
		isSecondary = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp(KeyCode.Tab))
		{
			isSecondary = !isSecondary;
		}

		if (isSecondary == false)
		{
			secondCamera.camera.active = false;
			mainCamera.camera.active = true;
		}else
		{
			secondCamera.camera.active= true;
			mainCamera.camera.active = false;
		}
	
	}
}
