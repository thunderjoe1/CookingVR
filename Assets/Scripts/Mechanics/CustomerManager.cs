/*******************************************************************************************************
Class Name:     CustomerManager
Author’s Name:  Thunder Clonch
Created Date:   02/15/2018
Description:    The class determines how many customers come into the restaurant.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerManager : MonoBehaviour
{
    [SerializeField]
    public static float difficulty = 15;                                    //Average number of seconds between customers arriving. A lower number is HARDER.
    [SerializeField]
    float duration;                                                 		//Duration of the workday in seconds.
    List<string> rushNames = new List<string>();                    		//Name of rushes that should occur this day in the order they occur.
    List<float> rushStarts = new List<float>();                     		//Start time in seconds of each rush in the order they occur.
    List<float> rushEnds = new List<float>();                       		//End time in seconds of each rush in the order they occur.
    List<float> rushDifficulty = new List<float>();                 		//The difficulty of each rush in the order that they occur. This is a multiplier so a difficulty of 0.5 makes customers arrive twice as fast.
    int rushNumber = 0;                                             		//The index number of the next/current rush.
    bool rushActive = false;                                         		//A bool that is true while a rush is happening.
    [SerializeField]
    float time;                                                     		//How long this script has been running.
    [SerializeField]
    float timeLast;                                                 		//Time in seconds that the last customer arrived.
    [SerializeField]
    float timeNext;                                                 		//Time in seconds when the next customer arrives.
    [SerializeField]
    public List<bool> customerSlot = new List<bool>();                     		//List of customer slots able to be used this level.
    [SerializeField]
    public List<CustomerScript> customers = new List<CustomerScript>();    	//List of customers currently in the store.
    public GameObject menuManager;                                 		 	//The GameObject that manages the order menu in the scene. Needs to be fed to the customers as they spawn.
	public OrderMenuManager orderMenuManager;								//The script attached to the above menumanager which manages the order screen in the game.
    public GameObject gameManager;                                  		//The GameObject that contains the game managers. Most importantly the OrderClass for the level.


    /*********************************
    Function Name: CustomerManager
    Functions Inputs: gameObject that the CustomerManager is added to, difficulty of the level, duration of the level, names of rushes for this level, start times of rushes this level, end times of rushes this level, the difficulty modifiers for each rush the order they occur, number of customer slots availible this level.
    Function Returns: the CustomerManager added by the function.
    Description and Use: Used to add a CustomerManager to an object while defining starting values.
    ***********************************/
    static public CustomerManager addCustomerManager(GameObject obj, float diff, float dur, int slots)
    {
        CustomerManager temp = obj.AddComponent<CustomerManager>();
		CustomerManager.difficulty = diff;
        temp.duration = dur;
        for (int i = 0; i < slots; i++)
        {
            temp.customerSlot.Add(false);
        }
        return temp;
    }

    void Awake()
    {
        time = 0;
        timeLast = 0;
		timeNext = whenNextCustomer ();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= timeNext)
        {
            generateCustomer();
        }
    }

    /*********************************
    Function Name: whenNextCustomer
    Functions Inputs: nothing, pulls data from variable stored in class
    Function Returns: float time stamp of next customer's arrival in seconds.
    Description and Use: Used to randomly determine the time till the next customer arrives.
    ***********************************/
    float whenNextCustomer()
    {
        if (rushActive)
        {
            return (timeLast + duration * rushDifficulty[rushNumber] / 2 + Random.Range(0,duration*rushDifficulty[rushNumber]) / 2);
        }
        else
        {
            return (timeLast + difficulty/2 + Random.Range(0,difficulty/2));
        }
    }

    /*********************************
    Function Name: generateCustomer
    Functions Inputs: nothing
    Function Returns: nothing
    Description and Use: Attempts to find an empty customer slot and adds a customer to this GameObject with that slot assigned. Sets the timeNext for the next customer's arrival.
    ***********************************/
    void generateCustomer()
    {
        timeLast = time;
        timeNext = whenNextCustomer();
        if(customers.Count < customerSlot.Count)
        {
            for (int i = 0; i < customerSlot.Count;)
            {
                if(customerSlot[i] == false)
                {
                    customers.Add(CustomerScript.addCustomerScript(gameObject, null, i));
                    customers[customers.Count - 1].gameManager = gameManager;
                    customers[customers.Count - 1].menuManager = menuManager;
                    customerSlot[i] = true;
                    i += customerSlot.Count;
                }
                i += 1;
            }
        }
        timeNext = whenNextCustomer();
    }

	/*********************************
    Function Name: removeCustomer
    Functions Inputs: int the slot of the customer to be removed.
    Function Returns: nothing
    Description and Use: Removes the customer given from the menu.
    ***********************************/
	public void removeCustomer(int slot)
	{
		orderMenuManager.changeImage (slot, menuManager.GetComponent<OrderMenuManager> ().foodIcons[0]);
		Destroy(customers[slot].myFood);
		customerSlot [slot] = false;
		Destroy (customers[slot]);
		customers.Remove (customers[slot]);
		redrawList ();
	}

	/*********************************
    Function Name: redrawList
    Functions Inputs: nothing
    Function Returns: nothing
    Description and Use: Slides the customers to the leftmost positions.
    ***********************************/
	public void redrawList ()
	{
		for (int i = 0; i <= customers.Count; i++)
		{
			if(customerSlot[i])
			{
				for (int n = 0; n < i;) 
				{
					if (customerSlot [n] == false) 
					{
						for (int r = 0; r < customers.Count;)
						{
							if (customers[r].slot == i)
							{
								customers [r].slot = n;
								customerSlot [n] = true;
								customerSlot [i] = false;
								orderMenuManager.changeImage (n, orderMenuManager.orderScreen[i].transform.GetChild(1).GetComponent<Image>().sprite);
								orderMenuManager.changeBar (i, 0);
								orderMenuManager.changeImage (i, orderMenuManager.foodIcons[0]);
								r += customers.Count;
							}
							r++;
						}
						n += customerSlot.Count;
					}
					n++;
				}
			}
		}
	}
}
