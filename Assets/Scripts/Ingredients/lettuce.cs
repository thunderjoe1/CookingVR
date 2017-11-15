/*******************************************************************************************************
Class Name:     patty
Author’s Name:  Thunder Clonch
Created Date:   10/12/2017
Description:    The class for hamburger patties.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lettuce : ingredientClass
{
    void Awake()
    {
        posCor = new Vector3(0, 0.0003f, 0);
        cooked = new Structs.cooked(0, 10, 20);
    }
}
