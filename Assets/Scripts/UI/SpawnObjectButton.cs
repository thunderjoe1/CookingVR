using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectButton : MonoBehaviour {

	public GameObject boxObject;
	GameObject spawnPoint;
	public int cost;

	// Use this for initialization
	void Start () {
		spawnPoint = GameObject.FindGameObjectWithTag ("Spawn Point");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OrderObject () {
		Instantiate (boxObject, spawnPoint.transform.position, boxObject.transform.rotation);
	}
}
