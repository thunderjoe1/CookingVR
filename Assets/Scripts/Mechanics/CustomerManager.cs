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

public class CustomerManager : MonoBehaviour
{
    float difficulty;                                               //Average number of seconds between customers arriving. A lower number is HARDER.
    float duration;                                                 //Duration of the workday in seconds.
    List<string> rushNames = new List<string>();                    //Name of rushes that should occur this day in the order they occur.
    List<float> rushStarts = new List<float>();                     //Start time in seconds of each rush in the order they occur.
    List<float> rushEnds = new List<float>();                       //End time in seconds of each rush in the order they occur.
    List<float> rushDifficulty = new List<float>();                 //The difficulty of each rush in the order that they occur. This is a multiplier so a difficulty of 0.5 makes customers arrive twice as fast.
    int rushNumber = 0;                                             //The index number of the next/current rush.
    bool rushActive = true;                                         //A bool that is true while a rush is happening.
    float time;                                                     //How long this script has been running.
    float timeLast;                                                 //Time in seconds that the last customer arrived.
    float timeNext;                                                 //Time in seconds when the next customer arrives.
    List<bool> customerSlot = new List<bool>();                     //List of customer slots able to be used this level.
    List<CustomerScript> customers = new List<CustomerScript>();    //List of customers currently in the store.
    

    /*********************************
    Function Name: CustomerManager
    Functions Inputs: difficulty of the level, duration of the level, names of rushes for this level, start times of rushes this level, end times of rushes this level, the difficulty modifiers for each rush the order they occur, number of customer slots availible this level.
    Function Returns: nothing
    Description and Use: Constructor used to load values when creating this script.
    ***********************************/
    public CustomerManager(float diff, float dur, List<string> names, List<float> starts, List<float> ends, List<float> rDiff, int slots)
    {
        difficulty = diff;
        duration = dur;
        rushNames = names;
        rushStarts = starts;
        rushEnds = ends;
        rushDifficulty = rDiff;
        for (int i = 0; i < slots; i++)
        {
            customerSlot.Add(false);
        }
    }

    void Awake()
    {
        time = 0;
        timeLast = 0;
        timeNext = whenNextCustomer();
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
            return (timeLast + duration/2 + Random.Range(0,duration/2));
        }
    }

    /*********************************
    Function Name: generateCustomer
    Functions Inputs: nothing
    Function Returns: nothing
    Description and Use: 
    ***********************************/
    void generateCustomer()
    {
        customers.Add(new CustomerScript());
        timeNext = whenNextCustomer();
    }
}
