using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour {

	public Transform target;	// The target for the spawnees
	public Transform[] asteroids;	// The asteroids to be spawned
	public Transform[] ships;	// The ships to be spawned
	public ShakeEffect shakeEffect;
	public float xMin = -12.0f;	// The x minimum position of where they can be
	public float xMax = 12.0f;	// The x maximum position of where they can be
	public float rateOfSpawn = 0.5f;	// The rate of spawn
	public float SpawnerDuration = 3f;
	public float TimeSpawnerA_Active = 0f;
	public float TimeSpawnerS_Active = 0f;
	
	public float DifficultyTimer;
	public float DifficultyIncrement = 30f;
	
	public float TimeStampAsteroids;
	public float TimeStampShips;
	
	public float SpawnSpamLimiter = 0.4f;
	public float TryToSpawn = 0f;
	
	public bool spawnAsteroids = false;
	public float spawnChanceAsteroids = 5f;
	public bool spawnShips = false;
	public float spawnChanceShips = 5f;
	
	public static Queue<Transform> alienShips;

	// Use this for initialization
	void Awake() {
		alienShips = new Queue<Transform>();
	}
	
	void Start(){
		DifficultyTimer = DifficultyIncrement;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Time.timeSinceLevelLoad >= DifficultyTimer){
			IncreaseDifficulty();
			DifficultyTimer += DifficultyIncrement;
		}
		
		TryToSpawn += Time.deltaTime;
		TurnOn();
		
		if(spawnAsteroids){
			TimeSpawnerA_Active += Time.deltaTime;
			
			if((Time.time - TimeStampAsteroids) >= rateOfSpawn) {
				TimeStampAsteroids += rateOfSpawn;
				
				Transform asteroid = Instantiate(asteroids[Random.Range(0, asteroids.Length)], 
					new Vector3(Random.Range(xMin, xMax), transform.position.y, transform.position.z), Quaternion.identity) as Transform;
	
				Asteroid asteroidScript = asteroid.GetComponent<Asteroid>();
				asteroidScript.target = target;
				asteroidScript.shakeObject = shakeEffect;
				asteroid.GetChild(0).GetComponent<Tumble>().tumbleSpeed = Random.Range(1.0f, 5.0f);
			}
			
			if(TimeSpawnerA_Active >= SpawnerDuration){
				TimeSpawnerA_Active = 0f;
				spawnAsteroids = false;
			}
		}
		
		if(spawnShips){
			TimeSpawnerS_Active += Time.deltaTime;
			
			if((Time.time - TimeStampShips) >= rateOfSpawn) {
				TimeStampShips += rateOfSpawn;
				
				Transform ship = Instantiate(ships[Random.Range(0, ships.Length)],
					new Vector3(Random.Range(xMin, xMax), transform.position.y, transform.position.z), Quaternion.identity) as Transform;
	
				AlienShip shipScript = ship.GetComponent<AlienShip>();
				shipScript.target = target;
				shipScript.shakeObject = shakeEffect;
				alienShips.Enqueue(ship);
			}
				
			if(TimeSpawnerS_Active >= SpawnerDuration){
				TimeSpawnerS_Active = 0f;
				spawnShips = false;
			}
		}
	}
	
	public void TurnOn(){
		if(TryToSpawn < SpawnSpamLimiter)return;
		TryToSpawn = 0f;
		if(!HazardChecker.Instance.CanSpawnHazard())return;
		
		if(!spawnAsteroids){
			float i = Random.value;
			i = i * 100;
			if(i <= spawnChanceAsteroids){
				spawnAsteroids = true;
				TimeStampAsteroids = Time.time;
				HazardChecker.Instance.SpawnFromSpawner();
				return;
			}
		}
		
		if(!spawnShips){
			float i = Random.value;
			i = i * 100;
			if(i <= spawnChanceShips){
				spawnShips = true;
				TimeStampShips = Time.time;
				HazardChecker.Instance.SpawnFromSpawner();
				return;
			}
		}
	}
	
	public void IncreaseDifficulty(){
		spawnChanceAsteroids += 5f;
		spawnChanceShips += 5f;
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
