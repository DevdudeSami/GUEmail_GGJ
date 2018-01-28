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
	}

	public void OnPointerDown(PointerEventData eventData) {
		if(lightController.isWaitingForUserInput) {
			lightController.lightDown(lightIndex);
		}
	}

	public void OnPointerUp(PointerEventData eventData) {
		if(lightController.isWaitingForUserInput) {
			lightController.lightUp(lightIndex);
		}
	}
}
