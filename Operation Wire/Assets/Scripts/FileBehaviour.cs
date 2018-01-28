using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileBehaviour : MonoBehaviour {

	private bool hovering;
	private bool isOpen;

	private bool opened;

	private int delay = 0;

	private GameObject canvas;

	public int value = 0;

	VirusMovementBehaviour vir;

	public int getValue() {
		return value;
	}

	void Awake() {
		canvas = this.gameObject.transform.GetChild(0).gameObject;
		print(canvas.name);
		hovering = false;
		isOpen = false;
		opened = false;
	}

	void Update() {
		if (delay > 0) {
			delay--;
			return;
		}

		if (hovering && Input.GetKey(KeyCode.Space)) {
			print("OPEN FILE");

			open();
			// actually open file

		} else if (hovering) {
			print("CLOSE FILE");
			close();
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		VirusMovementBehaviour virus = coll.gameObject.GetComponent<VirusMovementBehaviour>();
		if (virus != null) {
			vir = virus;
			hovering = true;
			// display prompt
			canvas.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		VirusMovementBehaviour virus = coll.gameObject.GetComponent<VirusMovementBehaviour>();
		if (virus != null) {
			hovering = false;
			if (isOpen) close();
			canvas.SetActive(false);

		}
	}

	public void close() {
		isOpen = false;
		// delay = 40;
		canvas.gameObject.transform.GetChild(0).gameObject.SetActive(false);
		canvas.gameObject.transform.GetChild(1).gameObject.SetActive(true);
	}

	public void open() {
		if (!opened) {
			vir.totalValue += this.getValue();
		}
		opened = true;
		delay = 40;
		// isOpen = true;
		canvas.gameObject.transform.GetChild(0).gameObject.SetActive(true);
		canvas.gameObject.transform.GetChild(1).gameObject.SetActive(false);
	}

}
