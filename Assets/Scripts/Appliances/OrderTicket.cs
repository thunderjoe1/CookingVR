/*******************************************************************************************************
Class Name:     OrderTicket
Author’s Name:  Thunder Clonch
Created Date:   11/21/2017
Description:    The class stores and displays the details of an order to the player.

Last Edited:  03/06/2018
Last Editor: Thunder Clonch
Last Edit Description: Adding actual funcionality to this. Up until now it's been a placeholder.

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderTicket : MonoBehaviour
{
	public int order;		//The customer's slot number in the OrderMenuManager.

	public int orderNumber ()
	{
		return order;
	}

	public void setOrderNumber (int i)
	{
		order = i;
	}
}