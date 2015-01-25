using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	public Transform target;
	public GameObject explosion;
	public ShakeEffect shakeObject;
	public float speed = 5.0f;
	
	void Start() {
		if(!target) {
			target = GameObject.Find("Main Camera").transform;
		}		
	}

	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
	
	void OnMouseDown(){
		if(explosion != null) {
			Instantiate(explosion, transform.position, transform.rotation);
		}
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider other) {

		if(other.tag == "Player") {
			if(explosion != null) {
				Instantiate(explosion, transform.position, transform.rotation);
			}
			if(shakeObject) {
				shakeObject.shakeTime = 0.5f;
			}
			Destroy(gameObject);
		}
	}
}
