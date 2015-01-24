using UnityEngine;
using System.Collections;

public class GuiManager : MonoBehaviour {
	
	public GameObject TitleScreen;
	public GameObject GameScreen;
	public GameObject DeathScreen;
	public GameObject TutorialScreen;
	
	private static GuiManager instance = null;
	public static GuiManager Instance {get {return instance; }}
	
	void Awake () {
		// Required for singleton
		instance = this;
	}
	
	void Start(){
		if(TitleScreen != null)TitleScreen.SetActive(true);
		if(GameScreen != null)GameScreen.SetActive(false);
		if(DeathScreen != null)DeathScreen.SetActive(false);
		if(TutorialScreen != null)TutorialScreen.SetActive(false);
	}
	
	public void OnPressPlay(){
		TitleScreen.SetActive(false);
		TutorialScreen.SetActive(true);
	}
	
	public void OnEnterGameplay(){
		TutorialScreen.SetActive(false);
		GameScreen.SetActive(true);
	}
}
