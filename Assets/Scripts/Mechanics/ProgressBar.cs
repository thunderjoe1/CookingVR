/*******************************************************************************************************
Class Name: ProgressBar
Author’s Name: Will Gray
Created Date: 11.2.2017
Description: Controls the progress bars over cooking ingredients

Last Edited: 11.16.2017
Last Editor: Will Gray
Last Edit Description: Make canvas follow player position

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

	public GameObject progressBarSprite { get; protected set; }				//Reference to the colored bar part of the progress bar sprite
	public GameObject progressBarMinSprite { get; protected set; }			//Reference to the minimum bar on the progress bar

	Image progressSprite;													//Reference to the actual image component of the progress bar sprite

	Canvas myCanvas;														//Reference to the canvas attached to the object
	ingredientClass myIngredientParent;										//Reference to the ingredient the canvas is attached to
	float currentCookedValue;												//Reference to the current cooked value of the ingredient the canvas is attached to
	float minimumCookedValue;												//Reference to the minimum cooked value of the ingredient the canvas is attached to
	float maximumCookedValue;												//Reference to the maximum cooked value of the ingredient the canvas is attached to
	float pastCookedValue;													//Reference to the cooked value from the last frame in order to compare it to the current frame to see if the object is being cooked

	Vector3 minPosition = new Vector3 (0, -230, 0);							//The position of the minimum bar on the progress bar
	Vector3 maxPosition = new Vector3 (0, 230, 0);							//The position of the maximum bar on the progress bar

	void Start () {
		//Initialize all progress bar references
		ProgressBarIntialize ();
	}
	
	void Update () {
		//Control progress bar functionality
		ProgressBarControl ();
		CanvasBillboard ();
	}

	/*********************************
        Function Name: ProgressBarControl
        Functions Inputs: nothing
        Function Returns: nothing
        Description and Use:
            Used to controll functionality of the progress bar every frame
        ***********************************/
	void ProgressBarControl () {
		//Sets the current cooked value as a percentage
		currentCookedValue = myIngredientParent.currentCookedValue ()/100f;
		//If the cookedvalue from the last frame is equal to the currentCooked value, disable the progress bar
		if (currentCookedValue == pastCookedValue) {
			myCanvas.enabled = false;
		} else {
			myCanvas.enabled = true;
		}
		//Sets the size of the progress bar to reflect the percentage cooked
		progressBarSprite.GetComponent<RectTransform> ().sizeDelta = new Vector2 (238.6f, Mathf.Lerp(0, 460, currentCookedValue/maximumCookedValue));
		//Sets a pair of percentages on the progress bar that dictate when it changes colors
		float firstColorChange = minimumCookedValue / 2;
		float secondColorChange = Mathf.Lerp (minimumCookedValue, maximumCookedValue, 0.5f);
		//Checks to see where the current cooked value is and sets the color based on that
		if (currentCookedValue < firstColorChange) {
			progressSprite.color = Color.red;
		} else if (currentCookedValue >= firstColorChange && currentCookedValue < secondColorChange) {
			progressSprite.color = Color.Lerp (Color.red, Color.green, (currentCookedValue - firstColorChange) / minimumCookedValue);
		} else if (currentCookedValue >= secondColorChange && currentCookedValue < maximumCookedValue) {
			progressSprite.color = Color.Lerp (Color.green, Color.black, Mathf.Pow((currentCookedValue - secondColorChange) / ((maximumCookedValue - minimumCookedValue) / 2), 3));
		}
		//Updates the pastCookedValue at the end of the frame for use in the next frame
		pastCookedValue = currentCookedValue;
	}

	/*********************************
        Function Name: ProgressBarInitialize
        Functions Inputs: nothing
        Function Returns: nothing
        Description and Use:
            Used to initialize the progress bar references
        ***********************************/
	void ProgressBarIntialize () {
		//Sets the progress bar sprite and minimum bar by looking through the children of the canvas
		progressBarSprite = transform.GetChild (0).GetChild (0).gameObject;
		progressBarMinSprite = transform.GetChild (0).GetChild (1).gameObject;
		//Initialize the canvas, progressSprite and myIngredientParent components
		myCanvas = GetComponent<Canvas> ();
		progressSprite = progressBarSprite.GetComponent<Image> ();
		myIngredientParent = transform.parent.gameObject.GetComponent<ingredientClass> ();
		//Sets the current, minimum and maximum cooked values
		minimumCookedValue = myIngredientParent.howCooked ().min / 100f;
		maximumCookedValue = myIngredientParent.howCooked ().max / 100f;
		currentCookedValue = myIngredientParent.howCooked ().value;
		//Sets the position of the minimum and maximum bars
		progressBarMinSprite.GetComponent<RectTransform> ().anchoredPosition = Vector3.Lerp (minPosition, maxPosition, minimumCookedValue/maximumCookedValue);
	}

	void CanvasBillboard () {
		myCanvas.gameObject.transform.LookAt (PlayerReference.Instance.gameObject.transform);
	}
}
