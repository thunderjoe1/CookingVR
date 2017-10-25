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
    Vector3 foodThickness = new Vector3 (0,0,0);                            //The thickness of the food in question across the x, y; z axis.
    GameObject baseItem;                                                    //The starting ingredient from which the rest of the food is built.
    
    void Start ()
    {
        ingredients.Add(transform.GetChild(0).GetComponent<ingredientClass>());
        foodThickness += transform.GetChild(0).GetComponent<ingredientClass>().posCor;
        print(foodThickness);
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
        foodThickness += c.posCor;
        i.transform.localPosition = foodThickness;
        i.transform.localRotation = Quaternion.Euler(0,0,0);
        foodThickness += c.posCor;
        i.GetComponent<Rigidbody>().isKinematic = true;
        i.GetComponent<BoxCollider>().isTrigger = true;
        i.GetComponent<NewtonVR.NVRInteractableItem>().enabled = false;
        GetComponent<BoxCollider>().size = new Vector3(0.12f, foodThickness.y, 0.12f) + ingredients[0].posCor;
        GetComponent<BoxCollider>().center = foodThickness - ingredients[0].posCor;
    }

    //When this object collides with another, check if the other has an ingredientClass component. If so, add it to the food item.
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<ingredientClass>())
        {
            addIngredient(col.gameObject);
        }
    }
}