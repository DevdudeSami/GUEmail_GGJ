using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBehaviour : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		VirusMovementBehaviour virus = coll.gameObject.GetComponent<VirusMovementBehaviour>();
		if (virus != null) {
			if (virus.gainSize(20)) {
				virus.inventory.playHeartPickupSound();
				Destroy(this.gameObject);
			}
		}
	}

}
