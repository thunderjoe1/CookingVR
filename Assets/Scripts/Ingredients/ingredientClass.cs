/*******************************************************************************************************
Class Name:     ingredientClass
Author’s Name:  Thunder Clonch
Created Date:   10/12/2017
Description:    The parent class for all ingredients.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientClass : MonoBehaviour, IHeatable, ISeasonable
{												
	public Vector3 posCor { get; protected set; }                        //This x,y,z corridinate change so that the ingredient doesn't clip through its food.											
	public bool isCooking;
	public GameObject myCanvasChild;

	virtual public void Heat(cookingType cookType, float heatPerSecond)
	{
		
	}

	virtual public Structs.cooked howCooked(cookingType cookType)
	{
		throw new System.ArgumentException ("Not cooked in this way brev");
	}

	virtual public List<Structs.cooked> getCookedList ()
	{
		throw new System.ArgumentException ("Not cooked in this way brev");
	}

	virtual public float currentCookedValue (cookingType cookType) {
		throw new System.ArgumentException ("Not cooked in this way brev");
	}

	virtual public void Season (seasonType seasonType, float seasonValue) {

	}
}