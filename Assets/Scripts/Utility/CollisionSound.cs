using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public GameObject soundMaker;
    public AudioClip collisionSound;    //The clip played when this object collides with something.
    GameObject temp;                    //A variable that temporatily stores the last soundMaker object spawned.

    void OnCollisionEnter(Collision col)
    {
        temp = Instantiate(soundMaker, col.transform.position, Quaternion.identity);
        temp.GetComponent<AudioSource>().clip = collisionSound;
        temp.GetComponent<AudioSource>().Play();
		Destroy(temp, 1f);
    }
}