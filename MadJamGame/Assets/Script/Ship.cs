using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ship : MonoBehaviour {
	
	public float MaxHP = 50;
	public float HP = 50f;
	public Image healthBar;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = HP/MaxHP;
	}
	
	public void TakeDamage(float Damage){
		HP -= Damage;
		CheckDead();
	}
	
	public void HPRefil(){
		HP = MaxHP;
	}
	
	void OnTriggerEnter(Collider col){
		TakeDamage(10.0f);
	}
	
	public void CheckDead(){
		if(HP <= 0f){
			GuiManager.Instance.PlayerDeath();
		}
	}
}
