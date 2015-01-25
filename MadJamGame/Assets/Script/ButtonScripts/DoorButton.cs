using UnityEngine;
using System.Collections;

public class DoorButton : ShipButton {

    public AudioClip doorClosedSound;
    public AudioClip doorOpenSound;
    public AudioSource doorSoundSource;

    public bool doorClosed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenDoor() {
        if (doorClosed == false) {
            doorSoundSource.clip = doorOpenSound;
            doorSoundSource.Play();
            doorClosed = true;
        }
        else{
            doorSoundSource.clip = doorClosedSound;
            doorSoundSource.Play();
            doorClosed = false;
        }
    }
}
