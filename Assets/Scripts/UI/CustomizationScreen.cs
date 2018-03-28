using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationScreen : MonoBehaviour {

	public GameObject menuPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenOrderMenu () {
		foreach (GameObject menu in RoomController.Instance.menuPanels) {
			menu.SetActive (false);
			if (menu == menuPanel) {
				menuPanel.SetActive (true);
			}
		}
	}

	public void OrderObject () {

	}
}
