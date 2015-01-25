using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public Animator anim;
	public ChangeAlpha fadeWhite;
	public ChangeAlpha fadeBlack;
	public GameObject tunnel;

	private bool buttonPressed = false;

	public void GameStart() {
		StartCoroutine(TravelWormhole());
	}

	IEnumerator TravelWormhole() {
		// Play Animation
		if(anim) {
			anim.SetBool("Start", true);
		}
		yield return new WaitForSeconds(2.0f);
		fadeWhite.ToOpaque();

		yield return new WaitForSeconds(2.0f);

		tunnel.SetActive(true);
		fadeWhite.ToTransparent();

		yield return new WaitForSeconds(4.0f);

		fadeBlack.ToOpaque();

		yield return new WaitForSeconds(2.0f);


		Application.LoadLevel(1);
	}
}
