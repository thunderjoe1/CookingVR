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

public class ingredientClass : MonoBehaviour, IHeatable
{
	protected Structs.cooked cooked;
    public Vector3 posCor { get; protected set; }                           //This x,y,z corridinate change so that the ingredient doesn't clip through its food.
	public bool isCooking;													

	public void Heat(float heatPerSecond)
	{
		cooked.value += heatPerSecond * Time.deltaTime;
	}

	public Structs.cooked howCooked()
	{
		return cooked;
	}

	public float currentCookedValue () {
		return cooked.value;
	}
}