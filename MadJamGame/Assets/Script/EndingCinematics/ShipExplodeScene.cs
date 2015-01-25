using UnityEngine;
using System.Collections;

public class ShipExplodeScene : MonoBehaviour {

	public GameObject ship;
	public GameObject endUI;
	public GameObject bigBang;

	private Animator shipAnim;

	// Use this for initialization
	void Start () {
		if(ship) {
			shipAnim = ship.GetComponent<Animator>();
			StartCoroutine(ShipExplosion());
		}
	}
	
	IEnumerator ShipExplosion() {
		shipAnim.SetBool("Start", true);
		yield return new WaitForSeconds(5.0f);

		Instantiate(bigBang, ship.transform.position, Quaternion.identity);
		Destroy(ship);
		yield return new WaitForSeconds(2.0f);
		
		if(endUI) {
			endUI.SetActive(true);
		}

	}
}
