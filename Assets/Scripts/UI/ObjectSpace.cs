using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpace : MonoBehaviour {

	public applianceSize spaceSize;

	// Use this for initialization
	void Start () {
		RoomController.Instance.ghostList.Add (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
