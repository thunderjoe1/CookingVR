using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tenderizer : MonoBehaviour
{
    void OnCollisionEnter(Collision item)
    {
        print("Collided.");
        MonoBehaviour[] list = item.gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour mb in list)
        {
            if (mb is ITenderizable)
            {
                print("Works.");
                ITenderizable tenderizable = (ITenderizable)mb;
                tenderizable.Tenderize();
            }
        }
    }
}