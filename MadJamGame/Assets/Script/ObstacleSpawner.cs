using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour {

	public Transform target;	// The target for the spawnees
	public Transform[] asteroids;	// The asteroids to be spawned
	public Transform[] ships;	// The ships to be spawned
	public float xMin = -12.0f;	// The x minimum position of where they can be
	public float xMax = 12.0f;	// The x maximum position of where they can be
	public float rateOfSpawn = 5.0f;	// The rate of spawn

	public bool spawnAsteroids = true;
	public bool spawnShips = true;
	
	public static Queue<Transform> alienShips;

	private float timer;	// Timer for spawning spawnees

	// Use this for initialization
	void Awake() {
		timer = Time.time + rateOfSpawn;
		alienShips = new Queue<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		// Spawn asteroids
		if(timer < Time.time) {
			if(spawnAsteroids) {
				Transform asteroid = Instantiate(asteroids[Random.Range(0, asteroids.Length)], 
				new Vector3(Random.Range(xMin, xMax), transform.position.y, transform.position.z), Quaternion.identity) as Transform;

				asteroid.GetComponent<Asteroid>().target = target;
				asteroid.GetChild(0).GetComponent<Tumble>().tumbleSpeed = Random.Range(1.0f, 5.0f);
			}
			if(spawnShips) {
				Transform ship = Instantiate(ships[Random.Range(0, ships.Length)],
					new Vector3(Random.Range(xMin, xMax), transform.position.y, transform.position.z), Quaternion.identity) as Transform;

				ship.GetComponent<AlienShip>().target = target;
				alienShips.Enqueue(ship);
			}

			timer = Time.time + rateOfSpawn;
		}
	}

	// Honk at one of the ships
	public void HonkShip() {
		if(alienShips.Count > 0) {
			Transform alienShip = alienShips.Dequeue();
			while(alienShip == null && alienShips.Count > 0) {
				alienShip = alienShips.Dequeue();
			}
			if(alienShip != null) {
				alienShip.GetComponent<AlienShip>().Honk();
			}
		}
	}
}
