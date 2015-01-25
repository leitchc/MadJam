
using UnityEngine;
using System.Collections;

public class FireEffect : MonoBehaviour
{

    public GameObject particleSys;
    //Location
    public float xMin = 0.0f;
    public float xMax = 0.0f;
    public float yMin = 0.0f;
    public float yMax = 0.0f;
    //Scale
    public float minScale = 2.0f;//0.02f;
    public float maxScale = -2.0f;//-0.03f;
    private bool runOnce = false;
    // Use this for initialization
    void Start()
    {
        xMin = -particleSys.transform.localPosition.x;
        xMax = particleSys.transform.localPosition.x;
        yMin = particleSys.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (HazardChecker.Instance.GetHazardState("Fire Detected") == 1)
        {
            if (!runOnce)
            {
                particleSys.transform.localPosition = new Vector3(
                        particleSys.transform.localPosition.x - Random.Range(xMin, xMax),
                        particleSys.transform.localPosition.y - Random.Range(yMin, yMax),
                        particleSys.transform.localPosition.z);

                particleSys.transform.localScale = new Vector3(
                        particleSys.transform.localScale.x - Random.Range(minScale, maxScale),
                        particleSys.transform.localScale.y - Random.Range(minScale, maxScale),
                        particleSys.transform.localScale.z - Random.Range(minScale, maxScale));
                particleSys.particleSystem.enableEmission = true;
                runOnce = true;
            }
        }
        else
        {
            particleSys.particleSystem.enableEmission = false;
            runOnce = false;
        }
    }
}

