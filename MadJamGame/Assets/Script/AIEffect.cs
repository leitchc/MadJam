
using UnityEngine;
using System.Collections;

public class AIEffect : MonoBehaviour
{
    public Hazard aI;
    public GameObject spriteAI;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    	if(aI.isActive) {
    		spriteAI.SetActive(true);
    	} else {
    		spriteAI.SetActive(false);
    	}
    }
}

