using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltPepper : MonoBehaviour {

	ParticleSystem myParticles;

	void Start () {
		myParticles = GetComponent<ParticleSystem> ();
		myParticles.Stop ();
	}

	void Update () {
		if (Mathf.Abs (Vector3.Dot(transform.up, Vector3.down)) < 0.5) {
			myParticles.Stop ();
		} else {
			myParticles.Play ();
		}
	}
}
