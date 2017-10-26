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
    void Start ()
    {
        posCor = new Vector3(0, 0.001f, 0);
        cooked = new Structs.cooked(0, 5, 10);
    }
}