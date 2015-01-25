using UnityEngine;
using System.Collections;

public class FireEffect : MonoBehaviour {

	public ParticleSystem particleSys;
	//Location
	public float xMin = 1.0f;
	public float xMax = 10.0f;
	public float yMin = -10.0f;
	public float yMax = 0.0f;
	//Scale
	public float minScale = 0.02f;
	public float maxScale = 0.05f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(HazardChecker.Instance.GetHazardState("Fire Detected") == 1) {
			//particleSys.transform.localPosition.Set(Random.Range(xMin, xMax),Random.Range(yMin, yMax),0);
			particleSys.transform.localScale.Set(Random.Range(minScale, maxScale),Random.Range(minScale, maxScale), Random.Range(minScale, maxScale));
			particleSys.enableEmission = true;
		} else {
			particleSys.enableEmission = false;
		}
	}
}
