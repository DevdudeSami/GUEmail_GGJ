using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour {

	public string colour;

	void OnTriggerEnter2D(Collider2D coll) {
		VirusMovementBehaviour virus = coll.gameObject.GetComponent<VirusMovementBehaviour>();
		if (virus != null) {
			if (colour == "red" && virus.inventory.redKey != true) {
				virus.inventory.redKey = true;
				Destroy(this.gameObject);
			}
			else if (colour == "yellow" && virus.inventory.yellowKey != true) {
				virus.inventory.yellowKey = true;
				Destroy(this.gameObject);
			}
			else if (colour == "blue" && virus.inventory.blueKey != true) {
				virus.inventory.blueKey = true;
				Destroy(this.gameObject);
			}
		}


	}
}
