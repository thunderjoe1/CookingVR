/*******************************************************************************************************
Class Name:     PlayerStats
Author’s Name:  Thunder Clonch
Created Date:   02/13/2018
Description:    Stores the player's stats as well as functions dealing with those stats.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float money { get; private set; }


    //For testing at the moment.
    private void Awake()
    {
    }

    /*********************************
    Function Name: addMoney
    Functions Inputs: float change in money
    Function Returns: float new money value
    Description and Use: Changes the player's money stat by the input float. Positive
    numbers add and negative numbers subtract.

    ***********************************/
    public float addMoney(float change)
    {
        money += change;

        money = Mathf.Round(money * 100) / 100;

        return money;
    }




}
