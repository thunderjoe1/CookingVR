using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tenderizer : MonoBehaviour
{
    void OnCollisionEnter(Collision item)
    {
        MonoBehaviour[] list = item.gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour mb in list)
        {
            if (mb is ITenderizable)
            {
                ITenderizable tenderizable = (ITenderizable)mb;
                tenderizable.Tenderize();
            }
        }
    }
}