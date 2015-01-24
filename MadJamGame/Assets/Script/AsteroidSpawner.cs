using UnityEngine;
using System.Collections;

/*
	Spawns Asteroids
*/
public class AsteroidSpawner : MonoBehaviour {

	public Transform target;	// The target for the spawnees
	public Transform[] spawnees;	// Game Objects to be spawned
	public float xMin = -12.0f;	// The x minimum position of where they can be
	public float xMax = 12.0f;	// The x maximum position of where they can be
	public float rateOfSpawn = 5.0f;	// The rate of spawn

	private float timer;	// Timer for spawning spawnees

	// Use this for initialization
	void Awake() {
		timer = Time.time + rateOfSpawn;
	}
	
	// Update is called once per frame
	void Update () {
		// Spawn asteroids
		if(timer < Time.time) {
			Transform asteroid = Instantiate(spawnees[Random.Range(0, 3)], 
				new Vector3(Random.Range(xMin, xMax), transform.position.y, transform.position.z), Quaternion.identity) as Transform;
			asteroid.GetComponent<MoveTowards>().target = target;
			asteroid.GetChild(0).GetComponent<Tumble>().tumbleSpeed = Random.Range(1.0f, 5.0f);

			timer = Time.time + rateOfSpawn;
		}
	}
}
