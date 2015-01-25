using UnityEngine;
using System.Collections;

public class ShipEjectScene : MonoBehaviour {

	public GameObject endUI;

	// Use this for initialization
	void Start () {
		StartCoroutine(EjectScene());
	}
	
	IEnumerator EjectScene() {
		yield return new WaitForSeconds(2.0f);
		endUI.SetActive(true);
	}	
}
