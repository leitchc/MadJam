using UnityEngine;
using System.Collections;

public class Sort3D : MonoBehaviour {
	public string layerSort;
	// Use this for initialization
	void Start () {
		renderer.sortingLayerName = layerSort;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
