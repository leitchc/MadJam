using UnityEngine;
using System.Collections;

public class MuffinButton : ShipButton {

    public GameObject muffin;
    public GameObject startPos;
    public float drop_speed = 0.1f;
    public Transform target;

    public float fall_pos;
	// Use this for initialization
	void Start () {

        fall_pos = target.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

        transform.position.y.Equals(fall_pos);
        fall_pos = fall_pos - drop_speed;
	}

    public void DispenseMuffin() {

        //Instantiate(theObject, transform.position + transform.forward * 1.0, transform.rotation);
        float xPos = Random.Range(-0.5f, 0.5f); 
        Vector3 newVec = new Vector3(startPos.transform.position.x + xPos, startPos.transform.position.y, startPos.transform.position.z);
        Instantiate(muffin, newVec, Quaternion.identity);
        soundSource.clip = buttonSound;
        soundSource.Play();

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
           
            Destroy(gameObject);
        }
    }

}
