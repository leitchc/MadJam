﻿using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {

	public Transform target;	// The target for the spawnees
	public Transform[] asteroids;	// The asteroids to be spawned
	public Transform[] ships;	// The ships to be spawned
	public float xMin = -12.0f;	// The x minimum position of where they can be
	public float xMax = 12.0f;	// The x maximum position of where they can be
	public float rateOfSpawn = 5.0f;	// The rate of spawn

	public bool spawnAsteroids = true;
	public bool spawnShips = true;
	
	private float timer;	// Timer for spawning spawnees

	// Use this for initialization
	void Awake() {
		timer = Time.time + rateOfSpawn;
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
			}

			timer = Time.time + rateOfSpawn;
		}
	}
}
