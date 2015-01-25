using UnityEngine;
using System.Collections;

public class ShipExplodeScene : MonoBehaviour {

	public Animator shipAnim;
	public GameObject endUI;

	// Use this for initialization
	void Start () {
		if(shipAnim) {
			StartCoroutine(ShipExplosion());
		}
	}
	
	IEnumerator ShipExplosion() {
		shipAnim.SetBool("Start", true);
		yield return new WaitForSeconds(5.0f);

		yield return new WaitForSeconds(2.0f);
		
		if(endUI) {
			endUI.SetActive(true);
		}

	}
}
