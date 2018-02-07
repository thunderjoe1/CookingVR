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
    public GameObject selectRecipe(int n)
    {
        string temp = MasterFoodList.foodNamer(n);

        if(temp == "Burger")
        {
            return(burgerRecipeChooser(MasterFoodList.foodSpawner(n,new Vector3(100,100,100),new Vector3(0,0,0))));
        }else if(temp == "Steak")
        {
            return(steakRecipeChooser(MasterFoodList.foodSpawner(n, new Vector3(100, 100, 100), new Vector3(0, 0, 0))));
        }
        else
        {
            print("OrderClass chose a food that doesn't exist.");
            return (null);
        }
    }

    /*********************************
    Function Name: burgerRecipeChooser
    Functions Inputs: g GameObject of the food which is being used to build this recipie.
    Function Returns: nothing
    Description and Use: 

    ***********************************/
    public GameObject burgerRecipeChooser(GameObject g)
    {
        burgerClass bc;
        switch (Random.Range(0,5))
        {
            case 0:
                bc = g.GetComponent<burgerClass>();
                bc.addIngredientClass(g.AddComponent<patty>()as patty);
                bc.addIngredientClass(g.AddComponent<cheese>() as cheese);
                bc.addIngredientClass(g.AddComponent<topBun>() as topBun);
                print("I want a burger with a cheese.");
                return (g);
            case 1:
                bc = g.GetComponent<burgerClass>();
                bc.addIngredientClass(g.AddComponent<patty>() as patty);
                bc.addIngredientClass(g.AddComponent<cheese>() as cheese);
                bc.addIngredientClass(g.AddComponent<lettuce>() as lettuce);
                bc.addIngredientClass(g.AddComponent<tomatoSlice>() as tomatoSlice);
                bc.addIngredientClass(g.AddComponent<topBun>() as topBun);
                print("I want a burger with everything.");
                return (g);
            case 2:
                bc = g.GetComponent<burgerClass>();
                bc.addIngredientClass(g.AddComponent<patty>() as patty);
                bc.addIngredientClass(g.AddComponent<cheese>() as cheese);
                bc.addIngredientClass(g.AddComponent<lettuce>() as lettuce);
                bc.addIngredientClass(g.AddComponent<topBun>() as topBun);
                print("I want a burger with cheese and lettuce.");
                return (g);
            case 3:
                bc = g.GetComponent<burgerClass>();
                bc.addIngredientClass(g.AddComponent<patty>() as patty);
                bc.addIngredientClass(g.AddComponent<cheese>() as cheese);
                bc.addIngredientClass(g.AddComponent<patty>() as patty);
                bc.addIngredientClass(g.AddComponent<cheese>() as cheese);
                bc.addIngredientClass(g.AddComponent<topBun>() as topBun);
                print("I want a double cheeseburger.");
                return (g);
            case 4:
                bc = g.GetComponent<burgerClass>();
                bc.addIngredientClass(g.AddComponent<patty>() as patty);
                bc.addIngredientClass(g.AddComponent<topBun>() as topBun);
                print("I want a burger no cheese.");
                return (g);
            default:
                print("burgerRecipeChooser chose a recipe that doesn't exist");
                return (null);
        }
    }

    /*********************************
    Function Name: steakRecipeChooser
    Functions Inputs: g GameObject of the food which is being used to build this recipie.
    Function Returns: nothing
    Description and Use: 

    ***********************************/
    public GameObject steakRecipeChooser(GameObject g)
    {
        switch (Random.Range(0, 1))
        {
            case 0:
                steakClass sc = g.GetComponent<steakClass>();
                sc.addIngredientClass(g.AddComponent<meatIngot>() as meatIngot);
                print("I want a meat ingot please.");
                return (g);
            default:
                print("steakRecipeChooser chose a recipe that doesn't exist");
                return (null);
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
        if(o.GetType() == i.GetType())
        {
            List<ingredientClass> tempo = o.getIngredients();       //
            List<ingredientClass> tempi = i.getIngredients();       //
            if(o.name == "Burger(Clone)")
            {
                return (compareBurger(tempo,tempi));
            }else if(o.name == "steakClass")
            {
                return (0);
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
        float score = 0;                        //The score being giving for the food being tested.
        float maxScore;                         //The maximum score you can get for this food item.
        bool ingredientMatched = false;         //A bool that stores wether or not the current ingredient in the order food is matched with an ingredient in the input food.

        if (tempi.Count > tempo.Count)
        {
            maxScore = tempi.Count;
        } else
        {
            maxScore = tempo.Count;
        }

        for (int i = 0; i < tempi.Count; i++)
        {
            //For each ingredientClass in the input food...
            for (int o = 0; o < tempo.Count; o++)
            {
                //...check each of the ingredientClasses in the ordered food. Then mark them as matched so that they aren't checked twich by accident.
                if (ingredientMatched == true)
                {
                    //Skip ingredients that are already paired.
                } else if (tempi[i].GetType() == tempo[o].GetType())
                {
                    print(tempi[i].name);
                    if(tempi[i].name == "Cheese Slice(Clone)" || tempi[i].name == "Bottom Bun" || tempi[i].name == "Top Bun(Clone)" || tempi[i].name == "Lettuce Leaf(Clone)" || tempi[i].name == "Tomato Slice(Clone)")
                    {
						List<Structs.cooked> temp = tempi[i].getCookedList();
						bool isCooked = false;								//True if the food is cooked as opposed to being undercooked.
						bool isOvercooked = false;							//True if the food is overcooked.

						for (int n = 0; n < temp.Count; n++)
						{
							if(temp[n].value <= temp[n].max)
							{
								print("The " + tempi[i].name + " is undercooked. It was cooked via " + temp[n].cookType + ".");
							}else if(temp[n].value > temp[n].max && temp[n].value < temp[n].max + 2)
							{
								isCooked = true;
								print("The " + tempi[i].name + " is cooked. It was cooked via " + temp[n].cookType + ".");
							}
							else
							{
								isOvercooked = true;
								print("The " + tempi[i].name + " is overcooked. It was cooked via " + temp[n].cookType + ".");
							}
						}
						if(!isCooked && !isOvercooked)
						{
							score += 1;
							print("The " + tempi[i].name + " is undercooked.");
						}else if(isCooked && !isOvercooked)
						{
							score += 1;
							print("The " + tempi[i].name + " is cooked.");
						}else if (isOvercooked)
						{
							score += -1;
							print("The " + tempi[i].name + " is overcooked.");
						}else
						{
							throw new System.ArgumentException ("The isCooked and isOvercooked bools are in an invalid combination.");
						}
						print(tempi[i].name + " is tested.");
						tempo.Remove(tempo[o]);
						ingredientMatched = true;
                    } else if (tempi[i].name == "Patty(Clone)")
                    {
						List<Structs.cooked> temp = tempi[i].getCookedList();
						bool isCooked = false;								//True if the food is cooked as opposed to being undercooked.
						bool isOvercooked = false;							//True if the food is overcooked.

						for (int n = 0; n < temp.Count; n++)
						{
							if(temp[n].value <= temp[n].max)
							{
								print("The " + tempi[i].name + " is undercooked. It was cooked via " + temp[n].cookType + ".");
							}else if(temp[n].value > temp[n].max && temp[n].value < temp[n].max + 2)
							{
								isCooked = true;
								print("The " + tempi[i].name + " is cooked. It was cooked via " + temp[n].cookType + ".");
							}
							else
							{
								isOvercooked = true;
								score += (Mathf.Pow(((temp[n].max - temp[n].min) / (temp[n].value - temp[n].min)),2)*2)-1;
								print("The " + tempi[i].name + " is overcooked. It was cooked via " + temp[n].cookType + ".");
							}
						}
						if(!isCooked && !isOvercooked)
						{
							score += (Mathf.Pow((temp[0].value/temp[0].max),1/2)*-50)+1;
							print("The " + tempi[i].name + " is undercooked.");
						}else if(isCooked && !isOvercooked)
						{
							score += 1;
							print("The " + tempi[i].name + " is cooked.");
						}else if (isOvercooked)
						{
							print("The " + tempi[i].name + " is overcooked.");
						}else
						{
							throw new System.ArgumentException ("The isCooked and isOvercooked bools are in an invalid combination.");
						}
						print(tempi[i].name + " is tested.");
						tempo.Remove(tempo[o]);
						ingredientMatched = true;
                    } else
                    {
                        print(tempi[i].name + " isn't supposed to be on there.");
                        score += -1;
                    }
                }
                print("O = " + o);
            }
            ingredientMatched = false;
            print("I = " + i);
            print("i.count = " + tempi.Count);
            print("Score = " + score);
        }
        return ((score/maxScore));
    }
}