/*******************************************************************************************************
Class Name:     meatIngot
Author’s Name:  Thunder Clonch
Created Date:   10/31/2017
Description:    The class for steak ingredient.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meatIngot : ingredientClass, IHeatable, ITenderizable
{
    int tenderIndex = 0;

    void Start()
    {
        posCor = new Vector3(0, 0, 0);
		cookedList.Add (new Structs.cooked(cookingType.cooking, 0, 50, 100));
    }

    public void Tenderize()
    {
        tenderIndex++;
        print(tenderIndex);
    }
}
