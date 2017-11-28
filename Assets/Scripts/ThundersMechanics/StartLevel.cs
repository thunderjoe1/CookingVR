/*******************************************************************************************************
Class Name:     StartLevel
Author’s Name:  Thunder Clonch
Created Date:   11/02/2017
Description:    The class which applies the settings required at the begining of each level.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public static List<int> availibleFoods { get; protected set; } //The foods that are availible to be ordered.

    /*********************************
    Function Name: clearFoods
    Functions Inputs: nothing
    Function Returns: nothing
    Description and Use: Use this to clear the list of foods that a costomer can order during the next shift. 
    Use this and then addFood to build a menu for the next shift.
    ***********************************/
    public static void clearFoods()
    {
        availibleFoods = new List<int>();
    }

    /*********************************
    Function Name: addFood
    Functions Inputs: a foodClass named f
    Function Returns: nothing
    Description and Use: Use this to add the foodClass of a food you wish to be orderable in the next shift.
    Use clearFoods and then this to build a menu for the next shift.
    ***********************************/
    public static void addFood(int n)
    {
        availibleFoods.Add(n);
    }

    void Awake()
    {
        clearFoods();
    }

    public static void printMenu()
    {
        foreach (int f in availibleFoods)
        {
            print(MasterFoodList.foodNamer(f));
        }
    }
}