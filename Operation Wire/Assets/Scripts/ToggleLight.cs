using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleLight : MonoBehaviour, IPointerClickHandler {
	
	LightSequenceBehaviour lightController;
	
	public int lightIndex;

	bool isOn = false;
	
	// Use this for initialization
	void Awake () {
		lightController = this.gameObject.transform.parent.GetComponent<LightSequenceBehaviour>();

		this.gameObject.GetComponent<Image>().color = Color.white;		
	}
	
	// Update is called once per frame
	void Update () {
		if(lightController.lightShouldBeOn(lightIndex)) {
			if(!isOn) { turnOn(); }
		} else {
			if(isOn) { turnOff(); }
		}
	}

	void turnOn() {
		this.gameObject.GetComponent<Image>().color = Color.red;
		isOn = true;
	}
	void turnOff() {
		this.gameObject.GetComponent<Image>().color = Color.white;
		isOn = false;
	}

	public void OnPointerClick(PointerEventData eventData) {
		lightController.lightClicked(lightIndex);
	}
}
