using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POSScript : MonoBehaviour 
{
	public GameObject ticket;
	public GameObject printLocation;
	public GameObject orderScreen;

	public void printTicket (int orderNum)
	{
		GameObject temp = Instantiate (ticket, printLocation.transform.position, Quaternion.identity);
		temp.GetComponent<OrderTicket> ().order = orderNum;
		temp.transform.GetChild (0).transform.GetChild (0).GetComponent<Text> ().text = "Order: " + orderNum + "\n" + orderScreen.GetComponent<OrderMenuManager> ().orderScreen [orderNum].transform.GetChild (0).GetComponent<Text> ().text;
	}
}