﻿/*******************************************************************************************************
Class Name: SaltPepper
Author’s Name: Will Gray
Created Date: 11.28.2017
Description: Handles behaviour of salt and pepper particle systems

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltPepper : MonoBehaviour {

	ParticleSystem myParticles;							//Reference to the particle system attached to this game object
	public seasonType mySeasonType;
	public float seasonValue;

	void Start () {
		//Set the particle system reference and make sure it's off at start
		myParticles = GetComponent<ParticleSystem> ();
		myParticles.Stop ();
	}

	void Update () {
		//Check to see if the object is upside down. If it isn't, stop the particle system. If it is, let it play
		if (Vector3.Dot(transform.up, Vector3.down) < 0.3f) {
			myParticles.Stop ();
		} else {
			myParticles.Play ();
		}
	}

	//Runs whenever a particle collides with an object
	void OnParticleCollision (GameObject other) {
		//Put the salted and peppered interface here
		MonoBehaviour[] list = other.GetComponents<MonoBehaviour>();
		foreach (MonoBehaviour mb in list)
		{
			if (mb is ISeasonable)
			{
				ISeasonable seasonable = (ISeasonable)mb;
				seasonable.Season(mySeasonType, seasonValue);
			}
		}
	}
}
