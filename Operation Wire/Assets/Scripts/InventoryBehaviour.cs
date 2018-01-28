using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehaviour : MonoBehaviour {

	public bool redKey;
	public bool yellowKey;
	public bool blueKey;
	AudioSource keyAudio;
	AudioSource heartAudio;

	// Use this for initialization
	void Start () {

		redKey = yellowKey = blueKey = false;
		AudioSource[] audios = GetComponents<AudioSource>();
		keyAudio = audios[0];
		heartAudio = audios[1];

	}

	// Update is called once per frame
	void Update () {

		// if touching a key collider
		// set relevant colour to true

	}

	public void playPickupSound() {
		keyAudio.Play();
	}

	public void playHeartPickupSound() {
		heartAudio.Play();
	}

}
