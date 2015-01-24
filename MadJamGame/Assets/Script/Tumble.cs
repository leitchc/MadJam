using UnityEngine;
using System.Collections;

public class Tumble : MonoBehaviour {
	
	public float tumbleSpeed;
	
	void Start () {
		rigidbody.angularVelocity = Random.insideUnitSphere * tumbleSpeed;
	}
}
