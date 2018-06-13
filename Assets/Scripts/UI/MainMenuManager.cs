using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour 
{
	public GameObject hand1, hand2;
	public GameObject menuManager;
	public GameObject gameManager;
	public GameObject optionsScreen;
	public GameObject mainMenuScreen;
	public GameObject orderScreen;
	public float patience, frequency, speed;
	public Text patienceText, frequencyText, speedText;

	public void StartGame () 
	{
		orderScreen.SetActive (true);
		StartLevel.printMenu();

		CustomerManager temp = CustomerManager.addCustomerManager(gameManager, 20, 180, 7);
		temp.enabled = true;
		temp.menuManager = menuManager;
		temp.orderMenuManager = menuManager.GetComponent<OrderMenuManager>();
		temp.gameManager = gameManager;

		optionsScreen.SetActive (false);
		mainMenuScreen.SetActive (false);
		hand1.GetComponent<SteamVR_LaserPointer> ().thickness = 0;
		hand1.GetComponent<SteamVR_TrackedController> ().enabled = false;
		hand1.GetComponent<SteamVR_LaserPointer> ().enabled = false;
		hand1.GetComponent<VRUIInput> ().enabled = false;
		hand1.GetComponent<SteamVR_TrackedObject> ().enabled = false;
		hand2.GetComponent<SteamVR_LaserPointer> ().thickness = 0;
		hand2.GetComponent<SteamVR_TrackedController> ().enabled = false;
		hand2.GetComponent<SteamVR_LaserPointer> ().enabled = false;
		hand2.GetComponent<VRUIInput> ().enabled = false;
		hand2.GetComponent<SteamVR_TrackedObject> ().enabled = false;
	}

	public void QuitGame () 
	{
		Application.Quit ();
	}

	public void OptionsMenu () 
	{
		optionsScreen.SetActive (true);
		mainMenuScreen.SetActive (false);
	}

	public void MainMenu () 
	{
		mainMenuScreen.SetActive (true);
		optionsScreen.SetActive (false);
	}

	public void CustomerPatiencePlus()
	{
		if(patience < 600)
		{
			patience += 10;
		}
		CustomerScript.timeLimit = patience;
		patienceText.text = Mathf.Round(CustomerScript.timeLimit) + "s";
	}

	public void CustomerPatienceMinus() 
	{
		if(patience > 30)
		{
			patience += -10;
		}
		CustomerScript.timeLimit = patience;
		patienceText.text = Mathf.Round(CustomerScript.timeLimit) + "s";
	}

	public void CustomerFrequencyPlus() 
	{
		if(frequency < 120)
		{
			frequency += 5;
		}
		CustomerManager.difficulty = frequency;
		frequencyText.text = Mathf.Round(CustomerManager.difficulty) + "s";
	}

	public void CustomerFrequencyMinus() 
	{
		if (frequency > 15)
		{
			frequency += -5;
		}
		CustomerManager.difficulty = frequency;
		frequencyText.text = Mathf.Round(CustomerManager.difficulty) + "s";
	}

	public void CookSpeedPlus() 
	{
		if (speed < 1.1f)
		{
			speed = 1.11111f;
		} else if(speed < 1.25f)
		{
			speed = 1.25f;
		} else if(speed < 1.42f)
		{
			speed = 1.42857f;
		} else if (speed < 1.66f)
		{
			speed = 1.666666f;
		} else if(speed < 2)
		{
			speed = 2;
		} else if(speed < 2.5f)
		{
			speed = 2.5f;
		} else if (speed < 3.33f)
		{
			speed = 3.333333f;
		} else if (speed < 5)
		{
			speed = 5;
		} else if (speed < 10)
		{
			speed = 10;
		} else if (speed < 50)
		{
			speed = 50;
		}
		StoveTop.heatValue = speed;
		speedText.text = Mathf.Round(50/StoveTop.heatValue) + "s";
	}

	public void CookSpeedMinus() 
	{
		if(speed > 10)
		{
			speed = 10;
		}else if(speed > 5)
		{
			speed = 5;
		}else if(speed > 3.333333333f)
		{
			speed = 3.333333f;
		}else if(speed > 2.5f)
		{
			speed = 2.5f;
		}else if(speed > 2)
		{
			speed = 2;
		}else if(speed > 1.6666666666f)
		{
			speed = 1.666666f;
		}else if(speed >1.428577f)
		{
			speed = 1.42857f;
		}else if(speed > 1.25f)
		{
			speed = 1.25f;
		}else if (speed > 1.11111111111111111111f)
		{
			speed = 1.11111f;
		}else if (speed > 1)
		{
			speed = 1;
		}
		StoveTop.heatValue = speed;
		speedText.text = Mathf.Round(50/StoveTop.heatValue) + "s";
	}
}
