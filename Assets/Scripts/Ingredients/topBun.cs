/*******************************************************************************************************
Class Name:     topBun
Author’s Name:  Thunder Clonch
Created Date:   10/12/2017
Description:    The class for the top bun of a hamburger.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topBun : ingredientClass
{
    void Awake()
    {
        posCor = new Vector3(0, 0.014f, 0);
		cookedList.Add (new Structs.cooked(cookingType.cooking, 0, 10, 20));
    }
}