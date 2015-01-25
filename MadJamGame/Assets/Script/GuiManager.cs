using UnityEngine;
using System.Collections;

public class GuiManager : MonoBehaviour {
	
	public GameObject GameScreen;
	public GameObject DeathScreen;
	
	private static GuiManager instance = null;
	public static GuiManager Instance {get {return instance; }}
	
	void Awake () {
		// Required for singleton
		instance = this;
	}
	
	void Start(){
		if(GameScreen != null)GameScreen.SetActive(true);
		if(DeathScreen != null)DeathScreen.SetActive(false);
	}
	
	public void PlayerDeath(){
		DeathScreen.SetActive(true);
	}
	
	public void Restart(){
		Application.LoadLevel(Application.loadedLevelName);
	}
	
	public void Quit(){
		Application.LoadLevel("Menu");
	}
}
