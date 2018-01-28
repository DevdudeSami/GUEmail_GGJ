using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUpBehaviour : MonoBehaviour {

	private System.Random rnd;

	void Start() {
		rnd = new System.Random();
	}

	void OnTriggerEnter2D(Collider2D coll) {
		VirusMovementBehaviour virus = coll.gameObject.GetComponent<VirusMovementBehaviour>();
		if (virus != null) {

			VirusMovementBehaviour.PowerUp pup;

			if (rnd.Next(1, 10) == 1) {
				pup = VirusMovementBehaviour.PowerUp.INVINCIBILITY;
			} else if (rnd.Next(1, 10) < 8) {
				pup = VirusMovementBehaviour.PowerUp.SPEED;
			} else {
				pup = VirusMovementBehaviour.PowerUp.SLOW;
			}

			virus.givePowerUp(pup, rnd.Next(200, 400));
			Destroy(this.gameObject);
		}
	}

}
