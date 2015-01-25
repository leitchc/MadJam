using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {
	
	//Booleans that control if sfx or music are muted
	public bool MscMuted = false;
	//Both Btn and FX check if FX are muted - no need for third boolean
	public bool FXMuted = false;
	
	//Three audio sources loaded in the inspector. This is what plays all the audio.
	public AudioSource MscSource;
	public AudioSource BtnSource;
	public AudioSource FXSource;
	
	//Reference by instance
	private static AudioManager instance = null;
	public static AudioManager Instance {get {return instance; }}

	//The audio clips we want to play will all be loaded in here
	public List<AudioClip> MscTracks;
	public List<AudioClip> BtnTracks;
	public List<AudioClip> FXTracks;
	public List<AudioClip> HornTracks;

	void Awake () {
		// Required for singleton
		instance = this;
		
		Object[] tmp = Resources.LoadAll("ShipHorn");
		foreach (AudioClip a in tmp){
			HornTracks.Add(a);
		}
	}
	
	public void ToggleMuteFX(){
		FXMuted = !FXMuted;
	}
	
	public void ToggleMuteMuisic(){
		MscMuted = !MscMuted;
	}
	
	public void PlaySFX(){
		if(FXMuted) return;
		//Continue
  		
	}
	
	public void PlayHorn(){
		//muted yaddayadda
		AudioClip tmp = HornTracks[Random.Range(0,HornTracks.Count)];
		FXSource.clip = tmp;
		FXSource.Play();
	}
	
	public void PlayMusic(){
		if(MscMuted) return;
		//Continue
	}
	
}
