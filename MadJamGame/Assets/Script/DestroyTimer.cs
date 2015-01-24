using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {

	public float timer = 3.0f;

	void Start () {
		Destroy(gameObject, timer);
	}
}
