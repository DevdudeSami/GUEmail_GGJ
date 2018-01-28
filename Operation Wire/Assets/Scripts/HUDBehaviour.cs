using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDBehaviour : MonoBehaviour {

	public GameObject virusObject;
	private VirusMovementBehaviour virus;

	// Use this for initialization
	void Awake () {
		virus = virusObject.GetComponent<VirusMovementBehaviour>();
	}

	// Update is called once per frame
	void Update () {

	}
}
