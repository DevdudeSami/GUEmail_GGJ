using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDBehaviour : MonoBehaviour {

	public GameObject virusObject;
	private VirusMovementBehaviour virus;

	private GameObject hud;

	// Use this for initialization
	void Awake () {
		virus = virusObject.GetComponent<VirusMovementBehaviour>();
		hud = this.gameObject.transform.GetChild(0);
	}

	// Update is called once per frame
	void Update () {
		// update health


		// update keys


		// update value

	}
}
