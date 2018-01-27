using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleLight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	
	LightSequenceBehaviour lightController;
	
	public int lightIndex;

	bool isOn = false;
	
	// Use this for initialization
	void Awake () {
		lightController = gameObject.transform.parent.GetComponent<LightSequenceBehaviour>();

		gameObject.GetComponent<Image>().color = Color.white;		
	}
	
	// Update is called once per frame
	void Update () {
		if(lightController.shouldAllLightsBeRed) {
			gameObject.GetComponent<Image>().color = Color.red;
			isOn = true;
			return;
		} else if(lightController.shouldAllLightsBeGreen) {
			gameObject.GetComponent<Image>().color = Color.green;
			isOn = true;
			return;
		}

		if(lightController.lightShouldBeOn(lightIndex)) {
			if(!isOn) { turnOn(); }
		} else {
			if(isOn) { turnOff(); }
		}
	}

	void turnOn() {
		gameObject.GetComponent<Image>().color = Color.magenta;
		isOn = true;
	}
	void turnOff() {
		gameObject.GetComponent<Image>().color = Color.white;
		isOn = false;
	}

	public void OnPointerDown(PointerEventData eventData) {
		if(lightController.isWaitingForUserInput) {
			lightController.lightClicked(lightIndex);

			gameObject.GetComponent<Image>().color = Color.blue;
		}
	}

	public void OnPointerUp(PointerEventData eventData) {
		if(lightController.isWaitingForUserInput) {
			gameObject.GetComponent<Image>().color = Color.white;
		}
	}
}
