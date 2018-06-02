/*******************************************************************************************************
Class Name:     burgerClass
Author’s Name:  Thunder Clonch
Created Date:   10/12/2017
Description:    The class for hamburgers.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerClass : foodClass
{
    void Awake()
    {
        ingredients.Add(transform.GetChild(0).GetComponent<bottomBun>());
        foodThickness += transform.GetChild(0).GetComponent<bottomBun>().posCor;
    }

    override public void addIngredient(GameObject i)
    {
        ingredientClass c = i.GetComponent<ingredientClass>();      //The ingredientClass attached to i.
		i.GetComponent<Valve.VR.InteractionSystem.Throwable>().DetachNow(i.GetComponent<Valve.VR.InteractionSystem.Throwable>().hnd);
        ingredients.Add(c);
        i.transform.parent = this.transform;
		foodThickness += c.posCor;
		Destroy(i.GetComponent<Valve.VR.InteractionSystem.Throwable>());
		Destroy(i.GetComponent<Valve.VR.InteractionSystem.VelocityEstimator>());
		Destroy(i.GetComponent<Valve.VR.InteractionSystem.Interactable>());
		Destroy (i.GetComponent<Rigidbody>());
		i.GetComponent<BoxCollider>().isTrigger = true;
        i.transform.localPosition = foodThickness;
		i.transform.localRotation = Quaternion.Euler(0, Random.Range(0,360), 0);
//		i.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		i.GetComponent<BoxCollider> ().enabled = false;
		foodThickness += c.posCor;
//		i.GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<BoxCollider>().size = new Vector3(0.12f, foodThickness.y, 0.12f) + ingredients[0].posCor/* + ingredients[ingredients.Count - 1].posCor*/;
        GetComponent<BoxCollider>().center = foodThickness / 2;
    }
}