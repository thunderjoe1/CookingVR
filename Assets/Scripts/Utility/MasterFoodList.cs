/*******************************************************************************************************
Class Name:     masterFoodList
Author’s Name:  Thunder Clonch
Created Date:   11/02/2017
Description:    Script which relates each food in the game to an integer for easier access.

Last Edited:  11/07/2017
Last Editor: Thunder Clonch
Last Edit Description: Now creates a master list of all food and provides static functions that can be used.

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterFoodList : MonoBehaviour
{
    public MonoBehaviour mb;
    public string st = "burgerClass";
    public static GameObject[] allFoods { get; protected set; } //The prefabs of the foods that are in the game.

    void Awake()
    {
        allFoods = Resources.LoadAll<GameObject>("FoodPrefabs");
    }

    /*********************************
    Function Name: foodNamer
    Functions Inputs: i an integer index of the food wish to recieve the name of.
    Function Returns: String name of the food linked to that index.
    Description and Use: Use to recieve the name of the food linked to an index when you need it.

    ***********************************/
    static public string foodNamer (int i)
    {
        return (allFoods[i].name);
    }

    /*********************************
    Function Name: foodSpawner
    Functions Inputs: i an integer index of the food wish to recieve the name of.
                      l a Vector3 the location to spawn the food item.
                      r a Vector3 the rotation of the object when it spawns. 
    Function Returns: The GameObject that is instantiated.
    Description and Use: Use to spawn food items using their index value.

    ***********************************/
    static public GameObject foodSpawner(int i, Vector3 l, Vector3 r)
    {
        return (Instantiate(allFoods[i],l,Quaternion.Euler(l)));
    }
}