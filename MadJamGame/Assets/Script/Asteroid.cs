using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	public Transform target;
	public GameObject explosion;
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

	void OnTriggerEnter(Collider other) {

		if(other.tag == "Player") {
			if(explosion != null) {
				Instantiate(explosion, transform.position, transform.rotation);
			}
			Destroy(gameObject);
		}
	}
}
