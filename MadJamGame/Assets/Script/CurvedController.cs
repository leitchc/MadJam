using UnityEngine;
using System.Collections;
/*
    Code taken from http://answers.unity3d.com/questions/288835/how-to-make-plane-look-curved.html
    with minor modifications.
*/
public class CurvedController : MonoBehaviour {

	public Material[] mats;
	public float speedX = 0.25f;
	public float speedY = 0.05f;
	public float offsetStartY = -10.0f;
    public float offsetEndY = 10.0f;
    public float offsetStartX = -10.0f;
    public float offsetEndX = 10.0f;
	
	public static Vector2 Offset = Vector2.zero;
    
    private bool atEndX = false;
    private bool atEndY = false;
    private float startTimeX;
    private float startTimeY;
    void Start ()
    {
        startTimeX = Time.time;
        startTimeY = Time.time;
    }
	
	void FixedUpdate () {
		if(!atEndX) {
            Offset.x = Mathf.Lerp(offsetStartX, offsetEndX, (Time.time - startTimeX) * speedX);
        } else {
            Offset.x = Mathf.Lerp(offsetEndX, offsetStartX, (Time.time - startTimeX) * speedX);
        }

        if(Offset.x >= offsetEndX) {
            atEndX = true;
            startTimeX = Time.time;
        } else if(Offset.x <= offsetStartX) {
            atEndX = false;
            startTimeX = Time.time;
        }
    

        if(!atEndY) {
            Offset.y = Mathf.Lerp(offsetStartY, offsetEndY, (Time.time - startTimeY) * speedY);
        } else {
            Offset.y = Mathf.Lerp(offsetEndY, offsetStartY, (Time.time - startTimeY) * speedY);
        }

        if(Offset.y >= offsetEndY) {
            atEndY = true;
            startTimeY = Time.time;
        } else if(Offset.y <= offsetStartY) {
            atEndY = false;
            startTimeY = Time.time;
        }

		foreach(Material m in mats) {
            m.SetVector("_QOffset",Offset);
        }
	}
}
