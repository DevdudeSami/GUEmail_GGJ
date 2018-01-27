using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMovementBehaviour : MonoBehaviour {

	public GameObject keys;
	public GameObject folders;
	public InventoryBehaviour inventory;

	private float size;
	private bool colliding;

	private float xSpeed;
	private float ySpeed;

	public float getSize() {
		return size;
	}

	void Start () {
		xSpeed = 0;
		ySpeed = 0;
		size = 80;
		colliding = false;
	}

	void Awake () {
		inventory = this.gameObject.GetComponent<InventoryBehaviour>();
	}

	void Update () {
		this.transform.localScale = new Vector3(0.1f + (size * 0.0125f), 0.1f + (size * 0.0125f), 1);

		if (size <= 0) {
			lose();
		}

		xSpeed = 0;
		ySpeed = 0;
		if (!colliding) {
			if (Input.GetKey(KeyCode.LeftArrow)) {
				xSpeed = -0.03f;
			} else if (Input.GetKey(KeyCode.RightArrow)) {
				xSpeed = 0.03f;
			} else if (Input.GetKey(KeyCode.UpArrow)) {
				ySpeed = 0.03f;
			} else if (Input.GetKey(KeyCode.DownArrow)) {
				ySpeed = -0.03f;
			}
			this.transform.position += new Vector3(xSpeed, ySpeed, 0);
		}
		colliding = false;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		// xSpeed = 0;
		// ySpeed= 0;
		if (coll.gameObject.GetComponent<EnemyBehaviour>()) size-=10;
		KeyBehaviour key = coll.gameObject.GetComponent<KeyBehaviour>();
		if (key != null) {
			if (key.colour == "red" && this.inventory.redKey != true) this.inventory.redKey = true;
			else if (key.colour == "yellow" && this.inventory.yellowKey != true) this.inventory.yellowKey = true;
			else if (key.colour == "blue" && this.inventory.blueKey != true) this.inventory.blueKey = true;
		}
		FolderBehaviour folder = coll.gameObject.GetComponent<FolderBehaviour>();
		if (folder != null) {
			if (folder.locked == true) {
				if (folder.colour == "red" && this.inventory.redKey == true) {
					folder.locked = false;
					this.inventory.redKey = false;
					folder.gameObject.GetComponent<BoxCollider2D>().enabled = false;
				} else if (folder.colour == "yellow" && this.inventory.yellowKey == true) {
					folder.locked = false;
					this.inventory.yellowKey = false;
					folder.gameObject.GetComponent<BoxCollider2D>().enabled = false;
				} else if (folder.colour == "blue" && this.inventory.blueKey == true) {
					folder.locked = false;
					this.inventory.blueKey = false;
					folder.gameObject.GetComponent<BoxCollider2D>().enabled = false;
				}
			}
		}
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
