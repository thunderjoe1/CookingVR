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
    public List<GameObject> orderScreen = new List<GameObject>();		//The GameObject which contains the UI elements for the different order slots.
    public List<Sprite> foodIcons = new List<Sprite>();					//All of the sprites for the different burger orders. This list must be in the same order as the list of possible orders inside of OrderClass.
	public GameObject responseImage;									//The GameObject which contains the Image UI component which displays customer responses.
	public List<Sprite> responseIcons = new List<Sprite>();				//All of the sprites for the different customer responses. This list must be in the same order as the possible inputs of the customerResponse function.
	public List<AudioClip> responseAudio = new List<AudioClip>();		//All of the AudioClips for the different customer responses. This list must be in the same order as the possible inputs of the customerResponse function.

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
			orderScreen[slot].transform.GetChild(1).GetComponent<Image>().sprite = image;
        } else
        {
            Debug.Log("Attempted to add a customer to a screen slot that doesn't exist.");
        }
    }

	/*********************************
    Function Name: customerResponse
    Functions Inputs: int input: state you want the customer to be in: 0 = Happy, 1 = Meh; 2 = Angry. 
    Function Returns: nothing
    Description and Use: Use this to temporarily display a customer response face over the order menu.
    ***********************************/
	public void customerResponse (int input)
	{
		responseImage.GetComponent<Image>().sprite = responseIcons[input];
		responseImage.GetComponent<ResponseImage> ().time = 0;
		responseImage.GetComponent<AudioSource> ().clip = responseAudio [input];
		responseImage.SetActive (true);
		responseImage.GetComponent<AudioSource> ().Play (0);
	}

	public void changeBar (int customer, float timer) {
		orderScreen[customer].transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2 (0f, Mathf.Lerp(0f, 0.775f, timer/CustomerScript.timeLimit));

	}


}