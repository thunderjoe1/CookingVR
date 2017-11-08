/*******************************************************************************************************
Class Name:     TestScript
Author’s Name:  Thunder Clonch
Created Date:   11/07/2017
Description:    Used only to test functionality of other scripts.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Start()
    {
        StartLevel.addFood(Random.Range(0, 2));
        StartLevel.addFood(Random.Range(0, 2));
        StartLevel.addFood(Random.Range(0, 2));
        StartLevel.addFood(Random.Range(0, 2));
        StartLevel.addFood(Random.Range(0, 2));
        StartLevel.printMenu();
        StartLevel.clearFoods();
        StartLevel.printMenu();
    }
}
