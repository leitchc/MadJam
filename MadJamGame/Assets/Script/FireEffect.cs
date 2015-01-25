
using UnityEngine;
using System.Collections;

public class FireEffect : MonoBehaviour
{
    public Hazard fire;
    public GameObject particleSys;
    // horizontal screen: -0.46  to 0.46
    // vertical screen is: -0.19 to 0.27
    // spaceship's window is at 0.03 to 0.18
    //Location
    public float xMin = -0.46f;
    public float xMax = 0.46f;
    public float yMin = -0.19f;
    public float yMax = 0.27f;
    //Window vertical location
    public float winMin = 0.03f;
    public float winMax = 0.18f;
    //Scale
    public float minScale = 0.01f;
    public float maxScale = 0.12f;
    
    private bool runOnce = false;
    private static float lastTime = 0.0f;
    public float timeForFireGrow = 5.0f;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (fire.isActive == true)
        {
            if (!runOnce)
            {
                float yLoc = 0.0f;
                while((yLoc > winMin) && (yLoc < winMax))
                    yLoc = Random.Range(yMin, yMax);

                particleSys.transform.localPosition = new Vector3(
                    Random.Range(xMin, xMax), yLoc, particleSys.transform.localPosition.z);

                particleSys.transform.localScale = new Vector3( 
                    Random.Range(minScale, maxScale),
                    Random.Range(minScale, maxScale),
                    Random.Range(minScale, maxScale));
                particleSys.particleSystem.Play();    
                particleSys.particleSystem.enableEmission = true;
                runOnce = true;
            }
        }
        else
        {
            particleSys.particleSystem.Stop();
            particleSys.particleSystem.enableEmission = false;
            runOnce = false;
        }

        if(((lastTime + timeForFireGrow) <= Time.time) 
           && (particleSys.transform.localScale.x < particleSys.transform.localScale.x*5.0f) 
           && (particleSys.transform.localScale.y < particleSys.transform.localScale.y*5.0f)
           && (particleSys.transform.localScale.z < particleSys.transform.localScale.z*5.0f)
           ) {
            particleSys.transform.localScale = new Vector3( 
               particleSys.transform.localScale.x*1.15f,
               particleSys.transform.localScale.y*1.15f,
               particleSys.transform.localScale.z*1.15f);
            lastTime = Time.time;
        }
    }
}

