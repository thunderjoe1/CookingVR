using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(SteamVR_LaserPointer))]
public class VRUIInput : MonoBehaviour
{
	private SteamVR_LaserPointer laserPointer;
	private SteamVR_TrackedController trackedController;

	private void OnEnable()
	{
		laserPointer = GetComponent<SteamVR_LaserPointer>();
		laserPointer.PointerIn -= HandlePointerIn;
		laserPointer.PointerIn += HandlePointerIn;
		laserPointer.PointerOut -= HandlePointerOut;
		laserPointer.PointerOut += HandlePointerOut;

		trackedController = GetComponent<SteamVR_TrackedController>();
		if (trackedController == null)
		{
			trackedController = GetComponentInParent<SteamVR_TrackedController>();
		}
		trackedController.TriggerClicked -= HandleTriggerClicked;
		trackedController.TriggerClicked += HandleTriggerClicked;
	}

	private void HandleTriggerClicked(object sender, ClickedEventArgs e)
	{
		if (EventSystem.current.currentSelectedGameObject != null)
		{
			ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
		}
	}

	private void HandlePointerIn(object sender, PointerEventArgs e)
	{
		var button = e.target.GetComponent<Button>();
		Slider slider = e.target.GetComponent<Slider> ();
		if (button != null) 
		{
			button.Select ();
		} else if (slider != null) 
		{
			slider.Select ();
			if (trackedController.padTouched) 
			{
				slider.value = Mathf.InverseLerp(-0.8f, 0.8f, SteamVR_Controller.Input((int)GetComponent<SteamVR_TrackedObject>().index).GetAxis(Valve.VR.EVRButtonId.k_EButton_DPad_Right).x);
				print (SteamVR_Controller.Input((int)GetComponent<SteamVR_TrackedObject>().index).GetAxis(Valve.VR.EVRButtonId.k_EButton_DPad_Right).x);
			}
		}
	}

	private void HandlePointerOut(object sender, PointerEventArgs e)
	{

		var button = e.target.GetComponent<Button>();
		Slider slider = e.target.GetComponent<Slider> ();
		if (button != null || slider != null)
		{
			EventSystem.current.SetSelectedGameObject(null);
			Debug.Log("HandlePointerOut", e.target.gameObject);
		}
	}
}