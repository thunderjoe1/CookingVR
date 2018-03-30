/*******************************************************************************************************
Class Name:     FoodTray
Author’s Name:  Thunder Clonch
Created Date:   11/21/2017
Description:    This class handles a tray that can hold an order ticket and several foods. This is referenced
by the order table for testing.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTray : MonoBehaviour
{
	[SerializeField]
	public int order { get; protected set; }					//The customer's slot number in the OrderMenuManager.
	[SerializeField]
	public GameObject ticket; /*{ get; protected set;}*/				//GameObject of the ticket on the tray. Null if there is no ticket.
	[SerializeField]
	public List<GameObject> foods  { get; protected set; }		//The list of foods currently on the tray.

	void Awake ()
	{
		foods = new List<GameObject> ();
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.GetComponent<foodClass>()) 
		{
			foods.Add (col.gameObject);
		} else if (col.gameObject.GetComponent<OrderTicket>()) 
		{
			order = col.gameObject.GetComponent<OrderTicket> ().orderNumber ();
			ticket = col.gameObject;
		}
	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.GetComponent<foodClass>())
		{
			foods.Remove (col.gameObject);
		}else if(col.gameObject.GetComponent<OrderTicket>())
		{
			ticket = null;
		}
	}
}