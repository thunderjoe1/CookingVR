/*******************************************************************************************************
Class Name:     bottomBun
Author’s Name:  Thunder Clonch
Created Date:   10/19/2017
Description:    The class for the bottom bun of a hamburger.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomBun : ingredientClass
{
	void Awake ()
    {
        posCor = new Vector3(0,0.006f,0);
        cooked = new Structs.cooked(0, 10, 20);
    }
}
