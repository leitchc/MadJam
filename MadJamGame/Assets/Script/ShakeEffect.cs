using UnityEngine;
using System.Collections;

/*
  Shakes the game object.

  Adapted code from http://forum.unity3d.com/threads/screen-shake-effect.22886/
*/
public class ShakeEffect : MonoBehaviour {

	public float shakeTime = 0;  // How long to shake the game object
	public float shakeAmount = 0.7f; // The amount to shake
	public float decreaseFactor = 1.0f;  // The rate of decay

	void Update() {
  		if (shakeTime > 0) {
    		transform.localPosition = Random.insideUnitSphere * shakeAmount;
    		shakeTime -= Time.deltaTime * decreaseFactor;
 
  		} else {
    		shakeTime = 0;
  		}
	}
}
