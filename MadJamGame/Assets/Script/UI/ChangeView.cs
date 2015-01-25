using UnityEngine;
using System.Collections;

public class ChangeView : MonoBehaviour {

	public GameObject[] oldViews;
	public GameObject[] newViews;

	public void ViewChange() {
		if(oldViews.Length > 0) {
			for(int i = 0; i < oldViews.Length; i++) {
				oldViews[i].SetActive(false);
			}
		}
		if(newViews.Length > 0) {
			for(int j = 0; j < newViews.Length; j++) {
				newViews[j].SetActive(true);
			}
		}
	}
}
