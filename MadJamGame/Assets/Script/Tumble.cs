using UnityEngine;
using System.Collections;

public class Tumble : MonoBehaviour {
	
	public float tumbleSpeed;
	public float moveSpeed;
	
	void Start ()
	{
		rigidbody.angularVelocity = Random.insideUnitSphere * tumbleSpeed;
		rigidbody.velocity = transform.forward * moveSpeed;
	}
}
