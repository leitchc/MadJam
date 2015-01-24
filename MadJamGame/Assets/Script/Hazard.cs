using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {
	
	public bool isActive = false;
	
	//Timer variables
	public float SpawnSpamLimiter = 0.1f;
	public float TryToSpawn = 0f;
	public float TimeToFailure;
	public float TimeActive = 0f;
	
	//How much damage this hazard causes to the Ship,
		//and whether it continues to cause famage repeatedly
	public float Damage;
	public bool Recurring;
	
	//A number from 1 to 100; determines likelihood of hazard spawning
	public int SpawnChance = 40;
	
	public Ship player;
	
	// Use this for initialization
	void Start () {
		//These should be set in the inspecter, but if they weren't default them here
		if(TimeToFailure == 0f)TimeToFailure = 5f;
		if(Damage == 0f)Damage = 1f;
		if(player == null)player = GameObject.FindGameObjectWithTag("Player").GetComponent<Ship>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//Turn the hazards on
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
		}
		
		
	}
	
	private void Activate(){
		if(HazardChecker.Instance.CanSpawnHazard()){
			int i = Random.Range(1, 101);
			if(i <= SpawnChance){
				isActive = true;
				HazardChecker.Instance.SpawnHazard();
			}
		}
	}
}
