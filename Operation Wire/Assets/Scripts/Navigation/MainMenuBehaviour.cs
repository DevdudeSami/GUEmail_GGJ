using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour {

	private Button btn;

	// Use this for initialization
	void Awake () {
		btn = this.gameObject.GetComponent<Button>();
		print("Loading");
		btn.onClick.AddListener(TaskOnClick);
	}

	// Update is called once per frame
	void TaskOnClick() {
		print("Loading");
		SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
	}
}
