using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkLinkBehaviour : MonoBehaviour {

	public string linkedScene;
	public int targetScore = -1;



	void OnTriggerEnter2D(Collider2D coll) {
		VirusMovementBehaviour virus = coll.gameObject.GetComponent<VirusMovementBehaviour>();
		if (virus != null && (targetScore < 0 || virus.totalValue >= targetScore)) {
			print("Loading");
			SceneManager.LoadScene(linkedScene, LoadSceneMode.Single);
		}

	}
}
