using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LightSequenceBehaviour : MonoBehaviour {

	private int[] steps;
	private int length = 3;
	private int currentStep; // 0 to ...
	
	private const int timeBetweenLights = 35;
	private int timeLeftToNextStep = 0;
	
	private bool isDead = false;
	private const int deadTime = 15;
	private int deadTimeTimer = 0;
	
	public bool isWaitingForUserInput = false;
	private int[] clickedLights;
	private int lightStepWaiting = 0;

	public bool shouldAllLightsBeRed = false;
	public bool shouldAllLightsBeGreen = false;

	// Use this for initialization
	void Start () {
		reset();
	}
	
	// Update is called once per frame
	void Update () {
		if(isWaitingForUserInput || shouldAllLightsBeRed || shouldAllLightsBeGreen) {
			return;
		}

		if(isDead) {
			deadTimeTimer++;
			
			if (deadTimeTimer >= deadTime) {
				isDead = false;
				deadTimeTimer = 0;
			}
			
			return;
		}
		
		timeLeftToNextStep++;
		
		if (timeLeftToNextStep >= timeBetweenLights) {
			timeLeftToNextStep = 0;
			
			currentStep++;
			isDead = true;

			if(currentStep == length) startCollectingInput();
		}
	}

	void startCollectingInput() {
		isWaitingForUserInput = true;
		clickedLights = new int[length];
		lightStepWaiting = 0;
	}
	
	IEnumerator nextLevel() {
        yield return new WaitForSeconds(2);

        reset();
	}

	void reset() {
		shouldAllLightsBeGreen = false;
        shouldAllLightsBeRed = false;

		isWaitingForUserInput = false;
		length++;
		currentStep = 0;
		
		steps = new int[length];
		for (int i = 0; i < length; i++) {
			steps[i] = Random.Range(0,5);
		}
	}

	bool checkInput() {
		return clickedLights.SequenceEqual(steps);
	}
	
	public bool lightShouldBeOn(int lightIndex) {
		return !isDead && lightIndex == steps[currentStep];
	}

	public void lightClicked(int lightIndex) {
		clickedLights[lightStepWaiting] = lightIndex;
		lightStepWaiting++;

		if(lightStepWaiting == length) {
			if(checkInput()) {
				shouldAllLightsBeGreen = true;
			} else {
				shouldAllLightsBeRed = true;
			}

			isWaitingForUserInput = false;
			StartCoroutine(nextLevel());
		}
	}
}
