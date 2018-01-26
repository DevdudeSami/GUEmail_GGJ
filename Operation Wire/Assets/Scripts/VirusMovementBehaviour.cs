using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMovementBehaviour : MonoBehaviour {

	private int size;

	private float xSpeed;
	private float ySpeed;

	void Start () {
		xSpeed = 0;
		ySpeed = 0;
		size = 5;
	}


	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {

		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {

		}
		if (Input.GetKeyDown(KeyCode.UpArrow)) {

		}
		if (Input.GetKeyDown(KeyCode.DownArrow)) {

		}
	}

	void changeSize(int n) {
		
	}
}
