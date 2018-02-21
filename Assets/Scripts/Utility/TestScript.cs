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
    public GameObject gameManager;
    bool tested = false;

    void Start()
    {
        StartLevel.printMenu();

        testFunction();
    }

    void Update ()
    {
    }

    void testFunction ()
    {
        gameManager.GetComponent<OrderClass>().selectRecipe(0);
    }
}