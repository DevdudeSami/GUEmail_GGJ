using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderBehaviour : MonoBehaviour {

	public Sprite plainFolder;

	public bool locked;
	public string colour;

	public void unlock() {
		if (locked) {
			locked = false;
			this.GetComponent<BoxCollider2D>().enabled = false;
			this.GetComponent<SpriteRenderer>().sprite = plainFolder;
			AudioSource unlockAudio = GetComponent<AudioSource>();
			unlockAudio.Play();
		}
	}

}
