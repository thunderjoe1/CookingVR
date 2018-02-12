/*******************************************************************************************************
Class Name:     tomatoSlice
Author’s Name:  Thunder Clonch
Created Date:   10/12/2017
Description:    The class for tomato slices.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomatoSlice : ingredientClass
{
	protected List<Structs.cooked> cookedList= new List<Structs.cooked> ();

    void Awake()
    {
        posCor = new Vector3(0, 0.0025f, 0);
		cookedList.Add (new Structs.cooked(cookingType.cooking, 0, 2, 3));
    }
		
	override public void Heat(cookingType cookType, float heatPerSecond)
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
			Structs.cooked newCooked = new Structs.cooked (cookingType.blank,0,0,0);
			newCooked.cookType = cookType;
			cookedList.Add (newCooked);
		}
	}

	override public Structs.cooked howCooked(cookingType cookType)
	{
		for (int i = 0; i < cookedList.Count; i++) {
			if (cookedList [i].cookType == cookType) {
				return cookedList [i];
			}
		}
		throw new System.ArgumentException ("Not cooked in this way brev");
	}

	override public List<Structs.cooked> getCookedList ()
	{
		return cookedList;
	}

	override public float currentCookedValue (cookingType cookType) {
		return howCooked (cookType).value;
	}
}
