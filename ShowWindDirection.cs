using UnityEngine;
using System.Collections;

//Script that uses two unity guiTextures to display the direction the wind
//is blowing 
public class ShowWindDirection : MonoBehaviour {

	#pragma strict
	
	bool show = false; 
	public GameObject target;


	void Update()
	{

		if(WindDirection.windSpeed < 0.0F)
		{
			if( show == false )
			{
			
				GameObject.Find("ArrowRight").guiTexture.enabled = false;
				guiTexture.enabled = true;
				show = true;
				Debug.Log("Left");

			}

		}

		if(WindDirection.windSpeed > 0.0F)
		{
			if( show == false )
			{
				GameObject.Find("ArrowLeft").guiTexture.enabled = false;
				//guiTexture.enabled = true;
				show = true;
				Debug.Log("Right");
				
			}
		}
	}

}
