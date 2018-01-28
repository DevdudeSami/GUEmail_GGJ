using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuBehaviour : MonoBehaviour, IPointerClickHandler, IPointerDownHandler {


	public void OnPointerClick(PointerEventData eventData) {
		print("Loading");
		SceneManager.LoadScene("Level 1", LoadSceneMode.Single);

	}



	public void OnPointerDown(PointerEventData eventData) {
		print("Loading");
		SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
	}



}
