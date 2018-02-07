/*******************************************************************************************************
Class Name:     cheese
Author’s Name:  Thunder Clonch
Created Date:   10/12/2017
Description:    The class for cheese slices for hamburgers.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheese : ingredientClass
{
    void Awake ()
    {
        posCor = new Vector3(0, 0.001f, 0);
		Structs.cooked newCooked = new Structs.cooked (cookingType.cooking, 0, 5, 10);
		cookedList.Add (newCooked);
    }
}