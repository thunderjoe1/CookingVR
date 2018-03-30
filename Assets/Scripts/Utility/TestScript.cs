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
    public GameObject menuManager;
    bool tested = false;

    void Start()
    {
        StartLevel.printMenu();

        testFunction();

        CustomerManager temp = CustomerManager.addCustomerManager(gameObject, 30, 180, new List<string>(), new List<float>(), new List<float>(), new List<float>(), 6);
        temp.enabled = true;
        temp.menuManager = menuManager;
        temp.gameManager = gameManager;
    }

    void Update ()
    {
    }

    void testFunction ()
    {
//        gameManager.GetComponent<OrderClass>().selectRecipe(0);
    }
}