/*******************************************************************************************************
Class Name:     OrderMenuManager
Author’s Name:  Thunder Clonch
Created Date:   02/18/2018
Description:    The class which manages the screens upon which the orders are displayed to the player.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderMenuManager : MonoBehaviour
{
    public List<GameObject> orderScreen = new List<GameObject>();
    public List<Sprite> foodIcons = new List<Sprite>();


    /*********************************
    Function Name: changeText
    Functions Inputs: int index number of customer slot to be changed, string text to change text to.
    Function Returns: nothing
    Description and Use: Use this to directly change the 
    ***********************************/
    public void changeText (int customer, string input)
    {
        if(customer <= orderScreen.Count && customer >= 0)
        {
            orderScreen[customer].transform.GetChild(0).GetComponent<Text>().text = input;
        } else
        {
            Debug.Log("Attempted to add a customer to a screen slot that doesn't exist.");
        }
    }

    /*********************************
    Function Name: addImage
    Functions Inputs: sprite the image to be added to the order.
    Function Returns: nothing
    Description and Use: Adds an image to the end of the list of images on the order.
    ***********************************/
    public void addImage(Sprite image)
    {

    }
}