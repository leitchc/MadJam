using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {
	public string levelName;

	public void LevelLoad() {
		Application.LoadLevel(levelName);
	}
}
