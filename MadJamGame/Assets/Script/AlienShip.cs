using UnityEngine;
using System.Collections;

public class AlienShip : MonoBehaviour {

	public Transform target;	// The target to go towards to
	public Vector3 avoidLocation;	// The location to head to after being honked
	public GameObject explosion;	// The explosion when colliding with another collider
	public float speed = 5.0f;	// How fast the game object is moving
	
	private bool beenHonked = false;	// If the ships have been honked at or not

	void Start() {
		if(!target) {
			target = GameObject.Find("Main Camera").transform;
		}
	}

	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
		if(!beenHonked) {
			transform.Find("Vehicle").LookAt(target);
        	transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    	} else {
    		transform.Find("Vehicle").LookAt(avoidLocation);
    		transform.position = Vector3.MoveTowards(transform.position, avoidLocation, step);
    	}
	}

	
	void OnTriggerEnter(Collider other) {

		if(other.tag == "Player") {
			if(explosion != null) {
				Instantiate(explosion, transform.position, transform.rotation);
			}
			Destroy(gameObject);
		}
	}

	// Honk at the Alien Ship
	public void Honk() {
		beenHonked = true;
	} 
}
