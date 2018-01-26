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
		size = 3;
	}

	void Update () {
		xSpeed = 0;
		ySpeed = 0;
		if (Input.GetKey(KeyCode.LeftArrow)) {
			xSpeed = -0.1f + (0.02f * size);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			xSpeed = 0.1f - (0.02f * size);
		} else if (Input.GetKey(KeyCode.UpArrow)) {
			ySpeed = 0.1f - (0.02f * size);
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			ySpeed = -0.1f + (0.02f * size);
		}
		this.transform.position += new Vector3(xSpeed, ySpeed, 0);
	}

	public void setSize(int n) {
		if (n > 0 && n <= 5) {
			size = n;
		}
	}


}
