using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveTop : MonoBehaviour
{
    void OnTriggerStay(Collider item)
    {
        MonoBehaviour[] list = item.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour mb in list)
        {
            if (mb is IHeatable)
            {
                IHeatable heatable = (IHeatable)mb;
                heatable.Heat(1);
            }
        }
    }
}
