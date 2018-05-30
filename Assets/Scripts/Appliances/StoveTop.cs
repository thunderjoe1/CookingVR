/*******************************************************************************************************
Class Name:                 StoveTop
Author’s Name:              William Grey
Created Date:               Couldn't tell you.
Description:                Cooks ingredients that trigger with this object's collider. Shows their progress bars and makes them make cooking noises.

Last Edited:                05/10/2018
Last Editor:                Thunder Clonch
Last Edit Description:      Making the stove play audio.

*******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveTop : MonoBehaviour
{
	private cookingType myCookType = cookingType.cooking;
	public static float heatValue;

    void OnTriggerStay(Collider item)
    {
        MonoBehaviour[] list = item.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour mb in list)
        {
            if (mb is IHeatable)
            {
                IHeatable heatable = (IHeatable)mb;
				heatable.Heat(myCookType, heatValue);
            }
        }
    }

	void OnTriggerEnter (Collider item)
    {
		MonoBehaviour[] list = item.GetComponents<MonoBehaviour>();
		foreach (MonoBehaviour mb in list)
		{
			if (mb is ingredientClass)
			{
				ingredientClass i = (ingredientClass)mb;
				i.myCanvasChild.SetActive (true);
				i.myCanvasChild.GetComponent<ProgressBar>().currentCookType = myCookType;
				i.isCooking = true;
                i.gameObject.GetComponent<AudioSource>().Play();
			}
		}
	}

	void OnTriggerExit (Collider item)
    {
		MonoBehaviour[] list = item.GetComponents<MonoBehaviour>();
		foreach (MonoBehaviour mb in list)
		{
			if (mb is ingredientClass)
			{
				ingredientClass i = (ingredientClass)mb;
				i.myCanvasChild.SetActive (false);
				i.isCooking = false;
                i.gameObject.GetComponent<AudioSource>().Stop();
			}
		}
	}
}
