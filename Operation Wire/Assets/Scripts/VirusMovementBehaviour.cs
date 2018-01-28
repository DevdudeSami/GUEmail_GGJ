using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMovementBehaviour : MonoBehaviour {


	private const float speed = 2f;
	private float dynamicSpeed;
	private Rigidbody2D rb;

	public InventoryBehaviour inventory;

	public int size = 80;
	private bool colliding;

	private float xSpeed;
	private float ySpeed;

	private int powerUpRemaining = 0;

	private PowerUp currentPowerUp;
	public enum PowerUp {SPEED, INVINCIBILITY, SLOW}

	private bool invincible;

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
		xSpeed = 0;
        ySpeed = 0;

		dynamicSpeed = speed;
		invincible = false;

		if (powerUpRemaining > 0) {
			applyPowerUp();
			powerUpRemaining--;
		}

        this.transform.localScale = new Vector3(0.1f + (size * 0.0125f), 0.1f + (size * 0.0125f), 1);

        if (size <= 0) {
            lose();
        }


        if (Input.GetKey(KeyCode.LeftArrow)) {
            xSpeed = -dynamicSpeed;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            xSpeed = dynamicSpeed;
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            ySpeed = dynamicSpeed;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            ySpeed = -dynamicSpeed;
        }

        rb.velocity = new Vector3(xSpeed, ySpeed, 0);

        colliding = false;
    }

	void OnCollisionEnter2D(Collision2D coll) {
		print("collision with " + coll.gameObject.name);
		// xSpeed = 0;
		// ySpeed= 0;
		if (coll.gameObject.GetComponent<EnemyBehaviour>()) loseSize(80);


		FolderBehaviour folder = coll.gameObject.GetComponent<FolderBehaviour>();
		if (folder != null) {
			if (folder.locked == true) {
				if (folder.colour == "red" && this.inventory.redKey == true) {
					this.inventory.redKey = false;
					folder.unlock();
				} else if (folder.colour == "yellow" && this.inventory.yellowKey == true) {
					this.inventory.yellowKey = false;
					folder.unlock();
				} else if (folder.colour == "blue" && this.inventory.blueKey == true) {
					this.inventory.blueKey = false;
					folder.unlock();
				}
			}
		}
	}

	public void givePowerUp(PowerUp pup, int duration) {
		currentPowerUp = pup;
		powerUpRemaining = duration;
	}

	void applyPowerUp() {
		switch (currentPowerUp) {
			case (PowerUp.SPEED):
				dynamicSpeed = dynamicSpeed * 0.6f;
				break;
			case (PowerUp.SLOW):
				dynamicSpeed = dynamicSpeed * 1.5f;
				break;
			case (PowerUp.INVINCIBILITY):
				invincible = true;
				break;
			default:
				break;
		}
	}


	public void loseSize(int n) {
		if (invincible) return;

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
