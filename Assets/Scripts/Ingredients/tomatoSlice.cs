/*******************************************************************************************************
Class Name:     tomatoSlice
Author’s Name:  Thunder Clonch
Created Date:   10/12/2017
Description:    The class for tomato slices.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomatoSlice : ingredientClass
{
    void Start()
    {
        posCor = new Vector3(0, 0.01f, 0);
        cooked = new Structs.cooked(0, 2, 2);
    }
}
