using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public void GameStart() {
		StartCoroutine(TravelWormhole());
	}

	IEnumerator TravelWormhole() {
		yield return new WaitForSeconds(2.0f);
		
	}
}
