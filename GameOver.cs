using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
	public float waitTime = 5;
	IEnumerator Start()
	{
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel(0);
	}
}

