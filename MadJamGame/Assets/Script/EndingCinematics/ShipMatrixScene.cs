using UnityEngine;
using System.Collections;

public class ShipMatrixScene : MonoBehaviour {

	public ChangeAlpha fadeWhite;
	public GameObject endUI;

	// Use this for initialization
	void Start () {
		StartCoroutine(MatrixScene());
	}

	IEnumerator MatrixScene() {
		fadeWhite.ToTransparent();

		yield return new WaitForSeconds(4.0f);

		endUI.SetActive(true);

	}
}
