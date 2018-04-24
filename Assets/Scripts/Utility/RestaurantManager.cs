using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestaurantManager : MonoBehaviour {

	public static RestaurantManager Instance { get; protected set; }

	public int money { get; protected set; }

	public Text moneyText;

	void Awake () {
		if (Instance != null) {
			print ("There can only be one");
		} else {
			Instance = this;
		}
		money = 500;
	}
	
	// Update is called once per frame
	void Update () {
		moneyText.text = "$" + money;
	}

	public int MoneyValue () {
		return money;
	}

	public void AddMoney (int moneyToAdd) {
		money += moneyToAdd;
	}

	public void SubtractMoney (int moneyToTake) {
		money -= moneyToTake;
		if (money <= 0) {
			money = 0;
		}
	}
}
