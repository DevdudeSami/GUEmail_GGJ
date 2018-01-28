using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour {

	public int[] direction;
	public float speed = 0.02f;
	private float distance = 0;
	private Rigidbody2D enemy;
	private int index = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (distance >= 1) {
			distance = 0f;
			goToNextPoint();
		}

		if (direction[index] == 0) this.transform.position += new Vector3(0, speed, 0);
		else if (direction[index] == 1) this.transform.position += new Vector3(speed, 0, 0);
		else if (direction[index] == 2) this.transform.position += new Vector3(0, -speed, 0);
		else if (direction[index] == 3) this.transform.position += new Vector3(-speed, 0, 0);

		distance += speed;

	}

	void goToNextPoint() {
		index++;
		if (index == direction.Length) index = 0;
	}

}
