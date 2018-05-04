using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour {

	public float force;

	void OnTriggerStay (Collider col) {
		if (col.GetComponent<Rigidbody> ()) {
			col.GetComponent<Rigidbody> ().velocity = new Vector3(force, 0, 0);
		}
	}
}
