/*******************************************************************************************************
Class Name:     DeliveryTable
Author’s Name:  Thunder Clonch
Created Date:   11/21/2017
Description:    This class detects trays placed in it and compares the order on it to the food on it.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryTable : MonoBehaviour
{
	public GameObject gameManager;
	public GameObject orderMenu;
	[SerializeField]
	CustomerManager customerManager;
	OrderClass orderClass;


	void Awake()
	{
		if (gameManager.GetComponent<OrderClass> ()) 
		{
			orderClass = gameManager.GetComponent<OrderClass> ();
		} else 
		{
			print ("Game managers is missing an OrderClass.");
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.GetComponent<FoodTray>())
		{
			if (gameManager.GetComponent<CustomerManager> ()) 
			{
				customerManager = gameManager.GetComponent<CustomerManager> ();
			} else 
			{
				print ("Game managers is missing a CustomerManager.");
			}
			FoodTray tray = col.gameObject.GetComponent<FoodTray> ();
			if (tray.ticket) 
			{
				float score = 0;			//The score of the current order.

				for (int n = 0; n <= customerManager.customers.Count; n++)
				{

					if (customerManager.customers [n].slot == tray.order) 
					{
						for (int i = 0; i < tray.foods.Count; i++) 
						{
							if (tray.foods [i].GetComponent<foodClass> ().GetType () == customerManager.customers[n].myFood.GetComponent<foodClass>().GetType()) 
							{
								score += orderClass.compareFoods (customerManager.customers [n].myFood.GetComponent<foodClass> (), tray.foods [i].GetComponent<foodClass> ());
							} else 
							{
								score += -5f;
							}
						}
						n += customerManager.customers.Count;
					}
				}
				for (int i = tray.foods.Count - 1; i >= 0; i--) 
				{
					Destroy (tray.foods[i]);
				}
				orderMenu.GetComponent<OrderMenuManager> ().changeImage(tray.order, orderMenu.GetComponent<OrderMenuManager> ().foodIcons[0]);
				CustomerScript temp = customerManager.customers [tray.order];
				Destroy(temp.myFood);
				customerManager.customers.Remove (temp);
				Destroy (temp);
				customerManager.customerSlot [tray.order] = false;
				Destroy (tray.ticket);
				Destroy (tray.gameObject);
				if (score >= 0) {
					RestaurantManager.Instance.AddMoney (Mathf.FloorToInt(score));
				} else if (score < 0) {
					RestaurantManager.Instance.SubtractMoney (5);
				}
			}
		}
	}
}