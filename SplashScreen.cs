using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour
{
	public float delayTime = 10;
	IEnumerator Start()
	{
		yield return new WaitForSeconds(delayTime);
		Application.LoadLevel(1);
	}
}

