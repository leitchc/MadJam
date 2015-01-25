using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {
	
	public bool isActive = false;
	public string h_name;
	
	//Timer variables
	public float SpawnSpamLimiter = 0.1f;
	public float TryToSpawn = 0f;
	
	public float InitialTimeToFailure;
	public float TimeToFailure;
	public float TimeActive = 0f;
	public float MinimumTime;
	
	public float DifficultyTimer;
	public float DifficultyIncrement = 30f;
	
	//How much damage this hazard causes to the Ship,
		//and whether it continues to cause famage repeatedly
	public float Damage;
	public bool Recurring;
	
	//A number from 1 to 100; determines likelihood of hazard spawning
	public float SpawnChance = 40f;
	
	public Ship player;
	
	// Use this for initialization
	void Start () {
		//These should be set in the inspecter, but if they weren't default them here
		if(h_name == "")h_name = "Unnamed";
		if(TimeToFailure == 0f)TimeToFailure = 5f;
		if(MinimumTime == 0f)MinimumTime = TimeToFailure;
		if(Damage == 0f)Damage = 5f;
		if(player == null)player = GameObject.FindGameObjectWithTag("Player").GetComponent<Ship>();
		
		DifficultyTimer = DifficultyIncrement;
		InitialTimeToFailure = TimeToFailure;
		
		//Initialize this hazard in the hazard checker
		HazardChecker.Instance.AddHazard(h_name, TimeToFailure);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Time.timeSinceLevelLoad >= DifficultyTimer){
			IncreaseDifficulty();
			DifficultyTimer += DifficultyIncrement;
		}
		
		//Try to turn the hazards on if they're off
		if(!isActive){
			TryToSpawn += Time.deltaTime;
			if(TryToSpawn > SpawnSpamLimiter){
				Activate();
				TryToSpawn = 0f;
			}
		}
		
		if(!isActive)return;
		
		TimeActive += Time.deltaTime;
		if(TimeActive >= TimeToFailure){
			player.TakeDamage(Damage);
			TimeActive = 0f;
			if(!Recurring)isActive = false;
			else{
				HazardChecker.Instance.SetHazardCountDown(h_name, TimeToFailure);
			}
		}
	}
	
	public void Activate(){
		if(HazardChecker.Instance.CanSpawnHazard()){
			float i = Random.value;
			i = i*100;
			if(i <= SpawnChance){
				isActive = true;
				HazardChecker.Instance.SpawnHazard(h_name);
			}
		}
	}
	
	public void IncreaseDifficulty(){
		if(SpawnChance < 50f)SpawnChance += 10f;
		else if(SpawnChance < 100f)SpawnChance = SpawnChance * 1.1f;
		else SpawnChance = 100f;
		
		TimeToFailure = InitialTimeToFailure * 0.8f;
		if(TimeToFailure <= MinimumTime)TimeToFailure = MinimumTime;
		
		HazardChecker.Instance.SetHazardDuration(h_name, TimeToFailure);
	}
}
