using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryBox : MonoBehaviour 
{
	public GameObject gameManager;
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
		if (col.gameObject.GetComponent<foodClass> ()) 
		{
			if (gameManager.GetComponent<CustomerManager> ())
			{
				customerManager = gameManager.GetComponent<CustomerManager> ();
			} else 
			{
				print ("Game managers is missing a CustomerManager.");
			}
			float score = 0;			//The score of the current order.

			if (col.gameObject.GetComponent<foodClass> ()) 
			{
				score += orderClass.compareFoods (customerManager.customers[0].myFood.GetComponent<foodClass> (), col.gameObject.GetComponent<foodClass> ());
			} else 
			{
				score += -5f;
			}
			ingredientClass[] ingredients = customerManager.customers[0].myFood.GetComponents<ingredientClass>();
			customerManager.removeCustomer (0);
			Destroy (col.gameObject);
/*			if (score >= 0) {
				RestaurantManager.Instance.AddMoney (Mathf.FloorToInt(score));
			} else if (score < 0) 
			{
				RestaurantManager.Instance.SubtractMoney (5);
			}*/
			if (score/(ingredients.Length + 1) >= 1)
			{
				customerManager.menuManager.GetComponent<OrderMenuManager> ().customerResponse (0);
			} else if (score/(ingredients.Length + 1) < 1 && score/(ingredients.Length + 1) > 0.5f)
			{
				customerManager.menuManager.GetComponent<OrderMenuManager> ().customerResponse (1);
			} else
			{
				customerManager.menuManager.GetComponent<OrderMenuManager> ().customerResponse (2);
			}
		}
	}
}