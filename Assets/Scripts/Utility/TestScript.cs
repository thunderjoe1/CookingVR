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
    public GameObject testFoodIn;
    public GameObject testFoodOrder;
    public GameObject gameManager;
    bool tested = false;

    void Start()
    {
        StartLevel.addFood(0);
        StartLevel.addFood(1);
        StartLevel.printMenu();

        OrderClass.Instance.orderFood();

        testFunction();
    }

    void Update ()
    {
        if(tested == false && testFoodIn && testFoodOrder)
        {
            tested = true;
            print(gameManager.GetComponent<OrderClass>().compareFoods(testFoodOrder.GetComponent<foodClass>(), testFoodIn.GetComponent<foodClass>()));
        }
    }

    void testFunction ()
    {
        print (MasterFoodList.foodSpawner(0,new Vector3(0,0,0),new Vector3(0,0,0)).GetComponent<foodClass>().name);
        gameManager.GetComponent<OrderClass>().selectRecipe(0);
    }
}