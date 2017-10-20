/*******************************************************************************************************
Class Name:     foodClass
Author’s Name:  Thunder Clonch
Created Date:   10/12/2017
Description:    The Parent class for all future food classes.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodClass : MonoBehaviour
{
    List<ingredientClass> ingredients = new List<ingredientClass>();        //List of ingredients that are a part of this food. 
    
    void Start ()
    {
        
    }

    /*********************************
    Function Name: addIngredient
    Functions Inputs: i GameObject of the ingredient being added.
    Function Returns: Nothing.
    Description and Use: Use to add an ingedient to the food running this function.

    ***********************************/
    public void addIngredient (GameObject i)
    {
        ingredientClass c = i.GetComponent<ingredientClass>();      //The ingredientClass attached to i.
        ingredients.Add(c);
        i.transform.parent = this.transform;
        if(c != ingredients[0])
        {
            i.transform.localPosition = c.posCor + ingredients[ingredients.Count - 1].posCor;
            i.transform.localRotation = Quaternion.Euler(0,0,0);
        }
        i.GetComponent<Rigidbody>().isKinematic = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<ingredientClass>())
        {
            print("Collision Enered.");
            addIngredient(col.gameObject);
        }
    }
}