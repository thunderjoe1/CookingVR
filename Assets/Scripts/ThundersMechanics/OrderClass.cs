/*******************************************************************************************************
Class Name:     OrderClass
Author’s Name:  Thunder Clonch
Created Date:   11/09/2017
Description:    The class which manages the orders people will decide to request.

Last Edited:  
Last Editor: 
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderClass : MonoBehaviour
{

    public static OrderClass Instance { get; protected set; }

    void Awake ()
    {
        if (Instance != null)
        {
            print("There should only be one Order Class what the fuck");
        } else
        {
            Instance = this;
        }
    }
    /*********************************
    Function Name: orderFood
    Functions Inputs: nothing
    Function Returns: nothing
    Description and Use: Runs selectFromMenu and then loads the output in selectRecipe.

    ***********************************/
    public void orderFood()
    {
        selectRecipe(selectFromMenu());
    }

    /*********************************
    Function Name: selectFromMenu
    Functions Inputs: nothing
    Function Returns: int index number of food that was chosen
    Description and Use: Chooses a random food from those currently on the menu.

    ***********************************/
    public int selectFromMenu()
    {
        return (Random.Range(0,StartLevel.availibleFoods.Count));
    }

    /*********************************
    Function Name: selectRecipe
    Functions Inputs: int index of the food which we want to choose a recipie from.
    Function Returns: nothing
    Description and Use: 

    ***********************************/
    public void selectRecipe(int n)
    {
        string temp = MasterFoodList.foodNamer(n);

        if(temp == "Burger")
        {
            burgerRecipeChooser(MasterFoodList.foodSpawner(n,new Vector3(100,100,100),new Vector3(0,0,0)));
        }else if(temp == "Steak")
        {
            steakRecipeChooser(MasterFoodList.foodSpawner(n, new Vector3(100, 100, 100), new Vector3(0, 0, 0)));
        }
        else
        {
            print("OrderClass chose a food that doesn't exist.");
        }
    }

    /*********************************
    Function Name: burgerRecipeChooser
    Functions Inputs: g GameObject of the food which is being used to build this recipie.
    Function Returns: nothing
    Description and Use: 

    ***********************************/
    public void burgerRecipeChooser(GameObject g)
    {
        switch (Random.Range(0,1))
        {
            case 0:
                burgerClass bc = g.GetComponent<burgerClass>();
                bc.addIngredientClass(g.AddComponent<patty>()as patty);
                bc.addIngredientClass(g.AddComponent<cheese>() as cheese);
                bc.addIngredientClass(g.AddComponent<topBun>() as topBun);
                print("I want a burger with a cheese.");
                break;
            case 1:
                print("burgerRecipeChooser chose a recipe that doesn't exist");
                break;
        }
    }

    /*********************************
    Function Name: steakRecipeChooser
    Functions Inputs: g GameObject of the food which is being used to build this recipie.
    Function Returns: nothing
    Description and Use: 

    ***********************************/
    public void steakRecipeChooser(GameObject g)
    {
        switch (Random.Range(0, 1))
        {
            case 0:
                steakClass sc = g.GetComponent<steakClass>();
                sc.addIngredientClass(g.AddComponent<meatIngot>() as meatIngot);
                print("I want a meat ingot please.");
                break;
            case 1:
                print("steakRecipeChooser chose a recipe that doesn't exist");
                break;
        }
    }

    /*********************************
    Function Name: compareFoods
    Functions Inputs: o foodClass the order the customer wants.
                      i foodClass the player is inputing to be scored.
    Function Returns: The score given to the player.
    Description and Use: Compares i to o and returns a score based on how close the player is to correct.

    ***********************************/
    public float compareFoods (foodClass o, foodClass i)
    {
        return (2);
        if(o.GetType() == i.GetType())
        {
            List<ingredientClass> tempo = o.getIngredients();       //
            List<ingredientClass> tempi = i.getIngredients();       //
            if(o.name == "burgerClass")
            {
                return (compareBurger(tempo,tempi));
            }else if(o.name == "steakClass")
            {

            }else
            {
                print("What did you even give me?");
                return (0);
            }
        }
        else
        {
            print ("You gave me the wrong food. What the fuck?");
            return (0);
        }
    }

    /*********************************
   Function Name: compareBurger
   Functions Inputs: tempo list of ingredientClasses that the customer is requesting.
                     tempi list of ingredientClasses that the player is giving the customer.
   Function Returns: The score given to the player.
   Description and Use: Compares tempi to tempo and returns a score based on how close the player is to correct.

   ***********************************/
    public float compareBurger(List<ingredientClass> tempo, List<ingredientClass> tempi)
    {
        foreach (ingredientClass ici in tempi)
        {
            foreach (ingredientClass ico in tempo)
            {
                if (ici.name == ico.name)
                {
                    if(ici.name == "cheese")
                    {
                        Structs.cooked temp = ici.howCooked();
                        if(temp.value <= temp.max)
                        {
                            return (1);
                        }else if(temp.value > temp.max && temp.value < temp.max + 2)
                        {
                            return ((temp.max - temp.value)+1);
                        }else
                        {
                            return (-1);
                        }
                    }
                    else
                    {
                        print("Something broke.");
                        return (0);
                    }
                    tempo.Remove(ico);
                    tempi.Remove(ici);
                    break;
                }
            }
        }
        print("Why?");
        return (0);
    }
}