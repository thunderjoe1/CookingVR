/*******************************************************************************************************
Class Name:     CustomerScript
Author’s Name:  Thunder Clonch
Created Date:   12/05/2017
Description:    This is a script that generates an order for the player to make.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    GameObject menuManager;                 //The GameObject with the OrderMenuManager which is displaying this customer.

    /*********************************
    Function Name: CustomerScript
    Functions Inputs: GameObject with the OrderMenuManager which is displaying this customer.
    Function Returns: nothing
    Description and Use: Constructor used to load values when creating this script.
    ***********************************/
    public CustomerScript (GameObject menu)
    {
        menuManager = menu;
    }

    void Start()
    {
        makeOrder();
    }

    void makeOrder()
    {

    }
}