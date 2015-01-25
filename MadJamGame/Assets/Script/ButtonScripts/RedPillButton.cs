using UnityEngine;
using System.Collections;

public class RedPillButton : ShipButton
{
    private bool isRunning = false;

    void Start() {

    }

    void Update() {

    }

    public void TakePill() {

        //yield return new WaitForSeconds(2);

        soundSource.clip = buttonSound;
        soundSource.Play();

        GameObject main = GameObject.Find("Main");

        if(!isRunning) {
            StartCoroutine(LoadMatrix());
        }
    }

    IEnumerator LoadMatrix() {
        isRunning = true;
        yield return new WaitForSeconds(1.0f);
        Application.LoadLevel("shipmatrix");
    }
}
