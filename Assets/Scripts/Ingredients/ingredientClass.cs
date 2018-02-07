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
	protected List<Structs.cooked> cookedList;
    public Vector3 posCor { get; protected set; }                        //This x,y,z corridinate change so that the ingredient doesn't clip through its food.
	public bool isCooking;													

	public void Heat(cookingType cookType, float heatPerSecond)
	{
		bool hasFound = false;		//Temp bool to determine if the cooktype has been found in the list or if a new one needs to be made
		for (int i = 0; i < cookedList.Count; i++) {
			if (cookedList[i].cookType == cookType) {
				cookedList [i].heatMe (heatPerSecond);
				hasFound = true;
				return;
			} 
		} 
		if (hasFound == false) {
			Structs.cooked newCooked = new Structs.cooked ();
			newCooked.cookType = cookType;
			cookedList.Add (newCooked);
		}
	}

	public Structs.cooked howCooked(cookingType cookType)
	{
		for (int i = 0; i < cookedList.Count; i++) {
			if (cookedList [i].cookType == cookType) {
				return cookedList [i];
			}
		}
		throw new System.ArgumentException ("Not cooked in this way brev");
	}

	public List<Structs.cooked> getCookedList ()
	{
		return cookedList;
	}

	public float currentCookedValue (cookingType cookType) {
		return howCooked (cookType).value;
	}

	public void Season (Structs.seasoned seasonStruct) {

	}
}