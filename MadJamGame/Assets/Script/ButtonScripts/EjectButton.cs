using UnityEngine;
using System.Collections;

public class EjectButton : ShipButton
{
    private bool isRunning = false;

    void Start() {

    }

    void Update() {

    }

    public void Eject() {

        //yield return new WaitForSeconds(2);

        soundSource.clip = buttonSound;
        soundSource.Play();

        GameObject main = GameObject.Find("Main");

        if(!isRunning) {
            StartCoroutine(LoadEject());
        }
    }

    IEnumerator LoadEject() {
        isRunning = true;
        yield return new WaitForSeconds(1.0f);
        Application.LoadLevel("shipeject");
    }
}
