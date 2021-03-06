﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour {

	public GameObject objectReference;
	public applianceSize mySize;
	public string myObjectName;

	Transform currentSpace;
	MeshRenderer myRender;
	BoxCollider myCollider;
	AudioSource mySound;
	NewtonVR.NVRInteractableItem NVRReference;
	bool isPlaced;

	// Use this for initialization
	void Start () {
		myRender = GetComponent<MeshRenderer> ();
		myCollider = GetComponent<BoxCollider> ();
		NVRReference = GetComponent<NewtonVR.NVRInteractableItem> ();
		mySound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		SnapObject ();
		DisplayGhosts ();
	}

	void SnapObject () {
		if (currentSpace != null && isPlaced == false) {
			if (GetComponent<NewtonVR.NVRInteractableItem> ().IsAttached == false) {
				transform.position = currentSpace.transform.position;
				transform.rotation = currentSpace.transform.rotation;
				mySound.Play ();
				myRender.enabled = false;
				objectReference.SetActive (true);
				GetComponent<Rigidbody> ().isKinematic = true;
				currentSpace.gameObject.SetActive (false);
				isPlaced = true;
			}
		}
	}

	void DisplayGhosts() {
		if (NVRReference.IsAttached == true) {
			foreach (GameObject ghost in RoomController.Instance.ghostList) {
				if (ghost.name == mySize + " Object Space") {
					ghost.SetActive (true);
					foreach (Transform child in ghost.transform) {
						if (child.gameObject.name == myObjectName + " Ghost") {
							child.gameObject.SetActive (true);
							print (myObjectName);
						} else {
							child.gameObject.SetActive (false);
							print (child.gameObject.name);
						}
					}
				}
			}
		} else {
			foreach (GameObject ghost in RoomController.Instance.ghostList) {
				ghost.SetActive (false);
			}
		}
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "Object Space") {
			if (coll.GetComponent<ObjectSpace> ().spaceSize == mySize) {
				currentSpace = coll.transform;

			}
		}
	}

	void OnTriggerExit(Collider coll) {
		currentSpace = null;
		if (isPlaced == true) {
			myCollider.enabled = false;
			Destroy (GetComponent<Rigidbody> ());
			NVRReference.enabled = false;
		}
	}
}
