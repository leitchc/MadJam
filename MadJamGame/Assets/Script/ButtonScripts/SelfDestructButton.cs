using UnityEngine;
using System.Collections;

public class SelfDestructButton : ShipButton
{

    public AudioClip explosionButtonSound;
    public AudioSource explosionSoundSource;

    private bool isRunning = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void Explode() {

        //yield return new WaitForSeconds(2);

        soundSource.clip = buttonSound;
        soundSource.Play();

        GameObject main = GameObject.Find("Main");

        explosionSoundSource.clip = explosionButtonSound;
        explosionSoundSource.Play();

        if(!isRunning) {
            StartCoroutine(LoadSelfDestruct());
        }
    }

    IEnumerator LoadSelfDestruct() {
        isRunning = true;
        yield return new WaitForSeconds(1.0f);
        Application.LoadLevel("shipexplode");
    }
}
