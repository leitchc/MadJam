using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	
	public bool MusicMuted = false;
	public bool FXMuted = false;
	
	public AudioSource MusicSource;
	public AudioSource FXSource;
	
	private static AudioManager instance = null;
	public static AudioManager Instance {get {return instance; }}
	
	void Awake () {
		// Required for singleton
		instance = this;
	}
	
	public void ToggleMuteFX(){
		FXMuted = !FXMuted;
	}
	
	public void ToggleMuteMuisic(){
		MusicMuted = !MusicMuted;
	}
	
	public void PlaySFX(){
		if(FXMuted) return;
		//Continue
	}
	
	public void PlayMusic(){
		if(MusicMuted) return;
		//Continue
	}
	
}
