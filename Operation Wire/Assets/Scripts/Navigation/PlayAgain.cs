using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayAgain : MonoBehaviour{

	public Button yourButton;

	void Start() {
		print("start");
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(goToScene);
	}



	public void goToScene() {
		print("Loading");
		SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
	}


}
