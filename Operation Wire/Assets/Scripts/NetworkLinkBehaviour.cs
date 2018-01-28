using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkLinkBehaviour : MonoBehaviour {

	public string linkedScene;

	void OnTriggerEnter2D(Collider2D coll) {
		VirusMovementBehaviour virus = coll.gameObject.GetComponent<VirusMovementBehaviour>();
		if (virus != null) {
			print("Loading");
			SceneManager.LoadScene(linkedScene, LoadSceneMode.Single);
		}

	}
}
