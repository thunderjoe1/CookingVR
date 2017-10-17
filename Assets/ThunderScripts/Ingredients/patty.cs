/*******************************************************************************************************
Class Name:     patty
Author’s Name:  Thunder Clonch
Created Date:   10/12/2017
Description:    The class for hamburger patties.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patty : ingrediantClass
{

    void Start ()
    {
        cooked = new Structs.cooked(0,50,100);
        print(cooked.value);
        print(cooked.min);
        print(cooked.max);
    }
}