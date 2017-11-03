/*******************************************************************************************************
Class Name:     masterFoodList
Author’s Name:  Thunder Clonch
Created Date:   11/02/2017
Description:    Script which relates each food in the game to an integer for easier access.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterFoodList : MonoBehaviour
{
    public MonoBehaviour mb;
    public string st = "burgerClass";

    static public GameObject foodIndexer (int i)
    {
        switch (i)
        {
            case 0:
                return (null);
            case 1:
                return (null);
            default:
                print("");
                return (null);
        }
    }
}