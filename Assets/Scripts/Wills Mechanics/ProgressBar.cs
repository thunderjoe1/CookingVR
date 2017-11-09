/*******************************************************************************************************
Class Name: ProgressBar
Author’s Name: Will Gray
Created Date: 11.2.2017
Description: 

Last Edited:
Last Editor:
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

	public GameObject progressBarSprite { get; protected set; }
	public GameObject progressBarMinSprite { get; protected set; }

	Image progressSprite;

	Canvas myCanvas;
	ingredientClass myIngredientParent;
	float currentCookedValue;
	float minimumCookedValue;
	float maximumCookedValue;

	Vector3 minPosition = new Vector3 (0, -230, 0);
	Vector3 maxPosition = new Vector3 (0, 230, 0);

	void Start () {
		ProgressBarIntialize ();
	}
	
	void Update () {
		ProgressBarControl ();
	}

	void ProgressBarControl () {
		currentCookedValue = myIngredientParent.currentCookedValue ()/100f;
		progressBarSprite.GetComponent<RectTransform> ().sizeDelta = new Vector2 (238.6f, Mathf.Lerp(0, 460, currentCookedValue/maximumCookedValue));
		float firstColorChange = minimumCookedValue / 2;
		float secondColorChange = Mathf.Lerp (minimumCookedValue, maximumCookedValue, 0.5f);
		if (currentCookedValue < firstColorChange) {
			progressSprite.color = Color.red;
		} else if (currentCookedValue >= firstColorChange && currentCookedValue < secondColorChange) {
			progressSprite.color = Color.Lerp (Color.red, Color.green, (currentCookedValue - firstColorChange) / minimumCookedValue);
		} else if (currentCookedValue >= secondColorChange && currentCookedValue < maximumCookedValue) {
			progressSprite.color = Color.Lerp (Color.green, Color.black, Mathf.Pow((currentCookedValue - secondColorChange) / ((maximumCookedValue - minimumCookedValue) / 2), 3));
		}
	}

	void ProgressBarIntialize () {
		progressBarSprite = transform.GetChild (0).GetChild (0).gameObject;
		progressBarMinSprite = transform.GetChild (0).GetChild (1).gameObject;
		myCanvas = GetComponent<Canvas> ();
		progressSprite = progressBarSprite.GetComponent<Image> ();
		myIngredientParent = transform.parent.gameObject.GetComponent<ingredientClass> ();
		minimumCookedValue = myIngredientParent.howCooked ().min / 100f;
		maximumCookedValue = myIngredientParent.howCooked ().max / 100f;
		currentCookedValue = myIngredientParent.howCooked ().value;
		SetMinAndMaxBars ();
	}

	void SetMinAndMaxBars () {
		progressBarMinSprite.GetComponent<RectTransform> ().anchoredPosition = Vector3.Lerp (minPosition, maxPosition, minimumCookedValue/maximumCookedValue);
	}
}
