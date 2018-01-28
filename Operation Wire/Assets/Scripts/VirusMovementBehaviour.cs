using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMovementBehaviour : MonoBehaviour {


	private const float speed = 2f;
	private Rigidbody2D rb;

	public InventoryBehaviour inventory;

	public int size = 80;
	private bool colliding;


	private float xSpeed;
	private float ySpeed;

	public float getSize() {
		return size;
	}

	void Start () {
		xSpeed = 0;
		ySpeed = 0;

		colliding = false;
	}

	void Awake () {
		inventory = this.gameObject.GetComponent<InventoryBehaviour>();
		rb = this.gameObject.GetComponent<Rigidbody2D>();
	}

	void Update () {
        this.transform.localScale = new Vector3(0.1f + (size * 0.0125f), 0.1f + (size * 0.0125f), 1);

        if (size <= 0) {
            lose();
        }

        xSpeed = 0;
        ySpeed = 0;

        if (Input.GetKey(KeyCode.LeftArrow)) {
            xSpeed = -speed;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            xSpeed = speed;
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            ySpeed = speed;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            ySpeed = -speed;
        }

        rb.velocity = new Vector3(xSpeed, ySpeed, 0);

        colliding = false;
    }

	void OnCollisionEnter2D(Collision2D coll) {
		print("collision with " + coll.gameObject.name);
		// xSpeed = 0;
		// ySpeed= 0;
		if (coll.gameObject.GetComponent<EnemyBehaviour>()) lose();
		KeyBehaviour key = coll.gameObject.GetComponent<KeyBehaviour>();

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


	public void loseSize(int n) {
		size -= n;
		if (size < 0) {
			size = 0;
		}
	}

	public void gainSize(int n) {
		size += n;
		if (size > 80) {
			size = 80;
		}
	}

	public void lose() {
		Destroy(this.gameObject);
	}


}
