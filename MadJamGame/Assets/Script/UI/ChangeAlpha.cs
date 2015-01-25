using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
	Code taken from http://answers.unity3d.com/questions/225438/slowly-fades-from-opaque-to-alpha.html
*/
public class ChangeAlpha : MonoBehaviour {

	private Image image;

	// Use this for initialization
	void Awake () {
		image = GetComponent<Image>();
	}

	 public void ToOpaque() {
	 	StartCoroutine(FadeTo(1.0f, 1.0f));
	 }

	 public void ToTransparent() {
	 	StartCoroutine(FadeTo(0.0f, 1.0f));
	 }
 
	IEnumerator FadeTo(float aValue, float aTime) {
		float alpha = image.color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
			Color newColor = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(alpha,aValue,t));
			image.color = newColor;
			yield return null;
		}
	}
}
