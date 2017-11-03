/*******************************************************************************************************
Class Name:     OrderClass
Author’s Name:  Thunder Clonch
Created Date:   10/31/2017
Description:    The class which manages the orders people will decide to request.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderScript : MonoBehaviour
{
    void Start()
    {
        StartLevel.clearFoods();
        StartLevel.addFood(0);
        StartLevel.addFood(1);
    }
}