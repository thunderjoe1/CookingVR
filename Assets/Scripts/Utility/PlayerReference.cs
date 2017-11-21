/*******************************************************************************************************
Class Name: PlayerReference
Author’s Name: Will Gray
Created Date: 11.16.2017
Description: Allows for a reference to the player game object

Last Edited: 11.16.2017
Last Editor: Will Gray
Last Edit Description: Make canvas follow player position

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReference : MonoBehaviour {

	public static PlayerReference Instance { get; protected set; }

	// Use this for initialization
	void Awake () {
		if (Instance != null) {
			print ("There should only be one player");
		} else {
			Instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
