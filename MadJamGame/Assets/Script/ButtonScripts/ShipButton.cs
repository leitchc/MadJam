using UnityEngine;
using System.Collections;

public class ShipButton : MonoBehaviour {

    public AudioClip buttonSound;
    public AudioSource soundSource;
    public Hazard hazard;
    public string b_name;
    
    public bool state = false;
    public float pressedTimer = 0f;
    
	// Use this for initialization
	void Start () {
		HazardChecker.Instance.AddButton(b_name, hazard.h_name);
	}
	
	void Update(){
		if(!state)return;
		pressedTimer += Time.deltaTime;
		if(pressedTimer >= 0.1f){
			HazardChecker.Instance.SetButtonState(b_name, false);
			state = false;
			pressedTimer = 0f;
		}
	}
	
	public void Clicked(){
		if(state)return;

        soundSource.clip = buttonSound;
        soundSource.Play();
		
		state = true;
		if(hazard.isActive){
			hazard.isActive = false;
			HazardChecker.Instance.SetHazardState(hazard.h_name, false);
		}
	}
}
