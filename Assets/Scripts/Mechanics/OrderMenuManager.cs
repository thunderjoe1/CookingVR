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
    Functions Inputs: int slot the index number of the slot on the screen being changed, Sprite image to replace that slot with.
    Function Returns: nothing
    Description and Use: Use this to directly change the image of an order menu slot on the screen in game.
    ***********************************/
	public void changeImage (int slot, Sprite image)
    {
		if(slot <= orderScreen.Count && slot >= 0)
        {
			orderScreen[slot].GetComponent<Image>().sprite = image;
        } else
        {
            Debug.Log("Attempted to add a customer to a screen slot that doesn't exist.");
        }
    }


	public void changeBar (int customer, float timer) {

		orderScreen[customer].transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2 (Mathf.Lerp(70f, 1940f, timer/90f), 336.2f);

	}
}