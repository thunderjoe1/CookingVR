/*******************************************************************************************************
Class Name:     CustomerScript
Author’s Name:  Thunder Clonch
Created Date:   12/05/2017
Description:    This is a script that generates an order for the player to make.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    public GameObject gameManager;		         	//The object with the game managment scripts attached. Specifically needs OrderClass on the object.
    public GameObject menuManager;                 	//The GameObject with the OrderMenuManager which is displaying this customer.
	public GameObject myFood;						//The food this customer orders.
    [SerializeField]
	public int slot { get; private set; }    		//The slot on the menu that this customer occupies.
	float time;										//The time in seconds this customer has existed.

    /*********************************
    Function Name: CustomerScript
    Functions Inputs: gameObject that the CustomerScript is added to. GameObject with the OrderMenuManager which is displaying this customer. int the number of the slot in the order system the customer is occupying.
    Function Returns: the CustomerScript that was added by this function.
    Description and Use: Used to add a CustomerScript to an object while defining starting values.
    ***********************************/
    public static CustomerScript addCustomerScript (GameObject obj, GameObject menu, int slotNum)
    {
        CustomerScript temp = obj.AddComponent<CustomerScript>();
        temp.menuManager = menu;
        temp.slot = slotNum;
        return temp;

    }

    void Start()
    {
        makeOrder();
		time = 0;
    }

	void Update()
	{
		time += Time.deltaTime;
		menuManager.GetComponent<OrderMenuManager> ().changeBar (slot, time);
		if(time >= 90)
		{
			menuManager.GetComponent<OrderMenuManager> ().changeText (slot, "");
			Destroy(myFood);
			gameManager.GetComponent<CustomerManager>().customers.Remove (this);
			gameManager.GetComponent<CustomerManager>().customerSlot [slot] = false;
			Destroy (this);
		}
	}

	void makeOrder()
    {
		myFood = gameManager.GetComponent<OrderClass>().selectRecipe(0, menuManager.GetComponent<OrderMenuManager>(), slot);
    }
}