using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseImage : MonoBehaviour 
{
	public float time = 0;

	void Update () 
	{
		time += Time.deltaTime;
		if (time >= 2)
		{
			gameObject.SetActive (false);
		}
	}
}