using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class LightSequenceBehaviour : MonoBehaviour {

	private AudioSource lightOnSound;
	private AudioSource lightPressedSound;
	private AudioSource correctSound;
	private AudioSource wrongSound;

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

	public Sprite[] backgrounds;
	private Image image;

	private bool lost = false;

	// Use this for initialization
	void Start () {
		AudioSource[] audios = gameObject.GetComponents<AudioSource>();

		lightOnSound = audios[1];
		lightPressedSound = audios[2];
		correctSound = audios[3];
		wrongSound = audios[4];

		image = gameObject.GetComponent<Image>();

		reset();
	}
	
	// Update is called once per frame
	void Update () {
		if(isWaitingForUserInput || shouldAllLightsBeRed || shouldAllLightsBeGreen) {
			
			if(shouldAllLightsBeGreen) {
				image.sprite = backgrounds[2];
			} else if(shouldAllLightsBeRed) {
				image.sprite = backgrounds[1];
			}

			return;
		}

		if(isDead) {
			deadTimeTimer++;
			
			if (deadTimeTimer >= deadTime) {
				isDead = false;
				deadTimeTimer = 0;
			}

			image.sprite = backgrounds[0];
			return;
		}
		
		for(int i = 0; i < 5; i++) {
			if(lightShouldBeOn(i)) {
				image.sprite = backgrounds[3+i];
			}
		}

		timeLeftToNextStep++;
		
		if (timeLeftToNextStep >= timeBetweenLights) {
			timeLeftToNextStep = 0;
			
			currentStep++;
			isDead = true;

			lightOnSound.Play();

			if(currentStep == length) startCollectingInput();
		}
	}

	void startCollectingInput() {
		image.sprite = backgrounds[0];
		isWaitingForUserInput = true;
		clickedLights = new int[length];
		lightStepWaiting = 0;
	}
	
	IEnumerator nextLevel() {
        yield return new WaitForSeconds(2);

        reset();
	}

	void reset() {
		if(lost) {

			SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
		}

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
		lost = !clickedLights.SequenceEqual(steps);
		return clickedLights.SequenceEqual(steps);
	}
	
	private bool lightShouldBeOn(int lightIndex) {
		return !isDead && lightIndex == steps[currentStep];
	}

	public void lightDown(int lightIndex) {
		image.sprite = backgrounds[8+lightIndex];
	}

	public void lightUp(int lightIndex) {
		clickedLights[lightStepWaiting] = lightIndex;
		lightStepWaiting++;

		lightPressedSound.Play();

		if(lightStepWaiting == length) {
			if(checkInput()) {
				correctSound.Play();
				shouldAllLightsBeGreen = true;
			} else {
				wrongSound.Play();
				shouldAllLightsBeRed = true;
			}

			isWaitingForUserInput = false;
			StartCoroutine(nextLevel());
		}

		image.sprite = backgrounds[0];
	}
}
