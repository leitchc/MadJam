﻿using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	
	public float HP = 50f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void TakeDamage(float Damage){
		HP -= Damage;
		if(HP <= 0f){
			//die
		}
	}
}