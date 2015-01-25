using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartGame : MonoBehaviour {

	public Animator anim;
	public ChangeAlpha fadeWhite;
	public ChangeAlpha fadeBlack;
	public GameObject tunnel;
	public GameObject starField;
	public Button quitButton;
	public Button creditButton;

	public void GameStart() {
		StartCoroutine(TravelWormhole());
	}

	IEnumerator TravelWormhole() {
		// Play Animation
		if(anim) {
			anim.SetBool("Start", true);
		}
		quitButton.enabled = false;
		creditButton.enabled = false;
		yield return new WaitForSeconds(2.0f);
		fadeWhite.ToOpaque();

		yield return new WaitForSeconds(2.0f);

		tunnel.SetActive(true);
		starField.SetActive(false);
		fadeWhite.ToTransparent();

		yield return new WaitForSeconds(4.0f);

		fadeBlack.ToOpaque();

		yield return new WaitForSeconds(2.0f);


		Application.LoadLevel(1);
	}
}
