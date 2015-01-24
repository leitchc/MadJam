using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	
	public float MaxHP = 50;
	public float HP = 50f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void TakeDamage(float Damage){
		HP -= Damage;
		CheckDead();
	}
	
	public void HPRefil(){
		HP = MaxHP;
	}
	
	void OnTriggerEnter(Collider col){
		HP -= 10;
		CheckDead();
	}
	
	public void CheckDead(){
		if(HP <= 0f){
			GuiManager.Instance.PlayerDeath();
		}
	}
}
