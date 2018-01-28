using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBehaviour : MonoBehaviour {

	public int targetValue = -1;

	public GameObject virusObject;
	private VirusMovementBehaviour virus;

	private GameObject hud;
	private GameObject keys;
	private GameObject health;
	private GameObject val;

	private int frame = 0;
	// Use this for initialization
	void Awake () {
		virus = virusObject.GetComponent<VirusMovementBehaviour>();
		hud = this.gameObject.transform.GetChild(0).gameObject;

		health = hud.transform.GetChild(0).gameObject;
		keys = hud.transform.GetChild(1).gameObject;
		val = hud.transform.GetChild(2).gameObject;

	}

	// Update is called once per frame
	void Update () {
		if (frame % 10 != 0) {
			frame++;
			return;
		}
		// update health
		float size = virus.getSize();
		for (int i = 0; i < 8; i++) {
			if ((i * 10) + 10  <= size) {
				health.transform.GetChild(i).gameObject.SetActive(true);
				health.transform.GetChild(i).gameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
			} else if ((i * 10) + 10 - size > 0 && (i * 10) + 10 - size < 10) {
				health.transform.GetChild(i).gameObject.SetActive(true);
				health.transform.GetChild(i).gameObject.GetComponent<RectTransform>().localScale = new Vector3(((i * 10) + 10 - size) * 0.1f, ((i * 10) + 10 - size) * 0.1f, 1f);
			} else {
				health.transform.GetChild(i).gameObject.SetActive(false);
			}
		}


		// update keys
		if (virus.inventory.redKey) {
			keys.transform.GetChild(0).gameObject.SetActive(true);
		} else {
			keys.transform.GetChild(0).gameObject.SetActive(false);
		}

		if (virus.inventory.blueKey) {
			keys.transform.GetChild(1).gameObject.SetActive(true);
		} else {
			keys.transform.GetChild(1).gameObject.SetActive(false);
		}

		if (virus.inventory.yellowKey) {
			keys.transform.GetChild(2).gameObject.SetActive(true);
		} else {
			keys.transform.GetChild(2).gameObject.SetActive(false);
		}


		// update value
		if (targetValue > 0 && virus.totalValue >= targetValue) {
			val.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Return to the root and exit";
		} else {
			val.transform.GetChild(0).gameObject.GetComponent<Text>().text = virus.totalValue.ToString();
		}



		frame++;
	}
}
