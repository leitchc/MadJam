using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	private bool buttonPressed = false;

	public void GameStart() {
		StartCoroutine(TravelWormhole());
	}

	void Update() {
		if(buttonPressed) {

		}
	}

	IEnumerator TravelWormhole() {
		yield return new WaitForSeconds(2.0f);

		Application.LoadLevel(1);
	}
}
