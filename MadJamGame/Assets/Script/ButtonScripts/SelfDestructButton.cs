using UnityEngine;
using System.Collections;

public class SelfDestructButton : ShipButton
{

    public AudioClip explosionButtonSound;
    public AudioSource explosionSoundSource;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Explode() {

        //yield return new WaitForSeconds(2);

        GameObject main = GameObject.Find("Main");
        GuiManager guiManager = (GuiManager)main.GetComponent(typeof(GuiManager));
        guiManager.PlayerDeath();

        explosionSoundSource.clip = explosionButtonSound;
        explosionSoundSource.Play();
    }
}
