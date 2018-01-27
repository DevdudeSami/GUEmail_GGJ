using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMovementBehaviour : MonoBehaviour {

	private const float speed = 2F;

	private float size;
	private bool colliding;

	private float xSpeed;
	private float ySpeed;

	private Rigidbody2D rb;

	public float getSize() {
		return size;
	}

	void Awake () {
		xSpeed = 0;
		ySpeed = 0;
		size = 80;
		colliding = false;

		rb = GetComponent<Rigidbody2D>();
	}

	void Update () {
		this.transform.localScale = new Vector3(0.1f + (size * 0.0125f), 0.1f + (size * 0.0125f), 1);

		if (size <= 0) {
			lose();
		}

		xSpeed = 0;
		ySpeed = 0;

		bool canMoveX = true;
		bool canMoveY = true;

		if (Input.GetKey(KeyCode.LeftArrow) && canMoveX) {
			xSpeed = -speed;
		} else if (Input.GetKey(KeyCode.RightArrow) && canMoveX) {
			xSpeed = speed;
		} 

		if (Input.GetKey(KeyCode.UpArrow) && canMoveY) {
			ySpeed = speed;
		} else if (Input.GetKey(KeyCode.DownArrow) && canMoveY) {
			ySpeed = -speed;
		}

		rb.velocity = new Vector3(xSpeed, ySpeed, 0);

		colliding = false;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		// xSpeed = 0;
		// ySpeed= 0;
		// if (coll.gameObject.GetComponent<EnemyBehaviour>()) size-=10;
	}


	public void setSize(int n) {
		if (n > 0 && n <= 5) {
			size = n;
		}
	}

	public void lose() {
		Destroy(this.gameObject);
	}


}
