using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeScript : MonoBehaviour {

	public Transform fridgeDoor;
	bool isOpen;
	public AudioSource[] myAudio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isOpen == false) {
			if (fridgeDoor.rotation.y < 0) {
				isOpen = true;
				myAudio [0].Play ();
			}
		}
		if (isOpen == true) {
			if (fridgeDoor.rotation.y >= 0) {
				isOpen = false;
				myAudio [1].Play ();
			}
		}
		print (isOpen);
	}
}
