/*******************************************************************************************************
Class Name:     ScreenSetup
Author’s Name:  Thunder Clonch
Created Date:   06/01/2018
Description:    Disables the parts of the screen that need to be disabled at game start.

Last Edited:  	
Last Editor: 	
Last Edit Description:	

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSetup : MonoBehaviour 
{
	public GameObject optionsMenu;

	void Start () 
	{
		optionsMenu.SetActive (false);
	}
}