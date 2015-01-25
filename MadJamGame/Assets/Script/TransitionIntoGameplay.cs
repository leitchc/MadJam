using UnityEngine;
using System.Collections;

public class TransitionIntoGameplay : MonoBehaviour {

	public void OnClick(){
		Application.LoadLevel("scene1");
	}
}
