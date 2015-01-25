using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public Text textUI;
	
	private float timer = 0;

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		string minutes = Mathf.Floor(timer / 60).ToString("00");
 		string seconds = Mathf.Floor(timer % 60).ToString("00");
		textUI.text = minutes + ":" + seconds;
	}
}
