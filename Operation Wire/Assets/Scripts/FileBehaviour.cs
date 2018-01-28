using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileBehaviour : MonoBehaviour {

	private BoxCollider2D bc;

	void Awake() {
		bc = this.gameObject.GetComponent<BoxCollider2D>();
	}

	void Update() {
		if (Input.GetKey(KeyCode.Space)) {
			bc.enabled = true;
		} else {
			bc.enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		VirusMovementBehaviour virus = coll.gameObject.GetComponent<VirusMovementBehaviour>();
		if (virus != null) {
			print("OPEN FILE");
			// open file
		}
	}

}
