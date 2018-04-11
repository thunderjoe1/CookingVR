using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveTop : MonoBehaviour
{
	private cookingType myCookType = cookingType.cooking;
	float heatValue = 5;

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

	void OnTriggerEnter (Collider item) {
		MonoBehaviour[] list = item.GetComponents<MonoBehaviour>();
		foreach (MonoBehaviour mb in list)
		{
			if (mb is ingredientClass)
			{
				ingredientClass i = (ingredientClass)mb;
				i.myCanvasChild.SetActive (true);
				i.myCanvasChild.GetComponent<ProgressBar>().currentCookType = myCookType;
				i.isCooking = true;
			}
		}
	}

	void OnTriggerExit (Collider item) {
		MonoBehaviour[] list = item.GetComponents<MonoBehaviour>();
		foreach (MonoBehaviour mb in list)
		{
			if (mb is ingredientClass)
			{
				ingredientClass i = (ingredientClass)mb;
				i.myCanvasChild.SetActive (false);
				i.isCooking = false;
			}
		}
	}
}
