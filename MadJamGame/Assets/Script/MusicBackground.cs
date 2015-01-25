using UnityEngine;
using System.Collections;

public class MusicBackground : MonoBehaviour {

	// Use this for initialization
	void Awake() {
		DontDestroyOnLoad(gameObject);
	}
}
