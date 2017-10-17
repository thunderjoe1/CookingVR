﻿/*******************************************************************************************************
Class Name:     ingredientClass
Author’s Name:  Thunder Clonch
Created Date:   10/12/2017
Description:    The parent class for all ingredients.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingrediantClass : MonoBehaviour, IHeatable
{
    protected Structs.cooked cooked;

    public void Heat(float heatPerSecond)
    {
        cooked.value += heatPerSecond * Time.deltaTime;
        print(cooked.value);
    }
}