using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

	public GameObject menuManager;
	public GameObject gameManager;
	public GameObject optionsScreen;
	public GameObject mainMenuScreen;
	public GameObject orderScreen;
	public Slider patience, frequency, speed;
	public Text patienceText, frequencyText, speedText;

	public void StartGame () {
		orderScreen.SetActive (true);
		StartLevel.printMenu();

		CustomerManager temp = CustomerManager.addCustomerManager(gameManager, 20, 180, 7);
		temp.enabled = true;
		temp.menuManager = menuManager;
		temp.orderMenuManager = menuManager.GetComponent<OrderMenuManager>();
		temp.gameManager = gameManager;

		mainMenuScreen.SetActive (false);
	}

	public void QuitGame () {
		Application.Quit ();
	}

	public void OptionsMenu () {
		optionsScreen.SetActive (true);
		mainMenuScreen.SetActive (false);
	}

	public void MainMenu () {
		mainMenuScreen.SetActive (true);
		optionsScreen.SetActive (false);
	}

	public void CustomerPatience() {
		CustomerScript.timeLimit = patience.value;
		patienceText.text = Mathf.Round(CustomerScript.timeLimit) + "s";
	}

	public void CustomerFrequency() {
		CustomerManager.difficulty = frequency.value;
		frequencyText.text = Mathf.Round(CustomerManager.difficulty) + "s";
	}

	public void CookSpeed() {
		StoveTop.heatValue = speed.value;
		speedText.text = Mathf.Round(50/StoveTop.heatValue) + "s";
	}
}
