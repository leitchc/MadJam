using UnityEngine;
using System.Collections;

public class AlienShip : MonoBehaviour {

	public Transform target;	// The target to go towards to
	public Vector3 avoidLocation;	// The location to head to after being honked
	public GameObject explosion;	// The explosion when colliding with another collider
	public float speed = 5.0f;	// How fast the game object is moving
	public float honkDecay = 3.0f;	// How long before you have to honk again
	
	private static bool beenHonked = false;	// If the ships have been honked at or not
	private static bool isRunning = false;	// Flag for the Coroutine
	private bool alreadyHonked = false;	// The ship has already been honked

	void Start() {
		if(!target) {
			target = GameObject.Find("Main Camera").transform;
		}
	}

	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
		if(!beenHonked || !alreadyHonked) {
			transform.LookAt(target);
        	transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    	} else {
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

	// Move Away from Target
	IEnumerator MoveAway() {
		if(!isRunning) {
			isRunning = true;
			beenHonked = true;
			alreadyHonked = true;

			yield return new WaitForSeconds(honkDecay);
			beenHonked = false;
			isRunning = false;
		}
	}

	// Honk at the Alien Ship
	public void Honk() {
		StartCoroutine(MoveAway());
	}
}
