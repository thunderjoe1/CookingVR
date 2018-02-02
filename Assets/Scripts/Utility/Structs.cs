/*******************************************************************************************************
Class Name:     structs
Author’s Name:  Thunder Clonch
Created Date:   10/12/2017
Description:    Script which stores our structs.

Last Edited: 
Last Editor: 
Last Edit Description: 

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structs : MonoBehaviour
{
    public struct cooked
    {
		public cookingType cookType;		//The type of cooking the ingredient is currently undergoing, be it cooking, baking, frying, or something else
        public float value;        //How cooked the ingredient is currently.
        public float max;          //How cooked the ingredient needs to be before it is considered burned.
        public float min;          //How cooked the ingredient needs to be before it is considered cooked.

        /*********************************
        Function Name: cooked
        Functions Inputs: cookType for the type of cooking the ingredient undergoes, v for the current ammount of cooked the ingredient is, i for the minimum cooked the ingredient needs to be; a for the max the ingredient can be before it is overcooked.
        Function Returns: nothing
        Description and Use:
            Used to initialize the cooked settings of an ingredient.
        ***********************************/
		public cooked(cookingType cookType, float v, float i, float a)
        {
			this.cookType = cookType;
            this.value = v;
            this.min = i;
            this.max = a;
        }
    }

	public struct seasoned {
		
	}
}

public enum cookingType { cooking, baking, frying};