using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		VirusMovementBehaviour virus = coll.gameObject.GetComponent<VirusMovementBehaviour>();
		if (virus != null) {
			virus.loseSize(5);
		}
	}

}
