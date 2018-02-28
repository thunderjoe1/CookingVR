using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour {

	public static RoomController Instance { get; protected set; }

	public List<GameObject> ghostList = new List<GameObject> ();


	void Awake () {
		if (Instance != null) {

		} else {
			Instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
