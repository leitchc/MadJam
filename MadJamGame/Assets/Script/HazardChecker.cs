using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

// Checks if button is pressed(in true state) and if corresponding hazard is also running(in true state)
// it will set the corresponding hazard to false. Also counts down roughly every second.
// If the countdown is less than 1 second, it will add the hazard to the failure list.
public class HazardChecker : MonoBehaviour {

	private static Dictionary<string, bool> hazards = new Dictionary<string, bool>();
	private static Dictionary<string, string> buttonAffects = new Dictionary<string, string>();
	private static Dictionary<string, bool> buttons = new Dictionary<string, bool>();

	private static List<string> failureList = new List<string>();

	private static Dictionary<string, float> hazardCountDown = new Dictionary<string, float>();
	private static Dictionary<string, float> hazardDuration = new Dictionary<string, float>();

	private static float lastTime = 0.0f;

	private static HazardChecker hazardObj = null;
	public static HazardChecker Instance {get {return hazardObj;}}

	// Howmany mistakes you're allowed to do until Game Over.
	public int ChancesTillLose = 0;

    // Use this for initialization
    void Awake () {
        hazardObj = this;
    }

	//------------------- Check if Exist methods -------------------

	// Checks if hazard exists in internal dictionary, true if it exist, false if it does not.
	public bool HazardExist(string hazardName) {
		return hazards.ContainsKey(hazardName);
	}

	// Checks if button exists in internal dictionary, true if it exist, false if it does not.
	public bool ButtonExist(string buttonName) {
		return hazards.ContainsKey(buttonName);
	}

	// Check if the failure list contains something, if so GAME OVER!
	public bool GameOver() {
		return (failureList.Count > ChancesTillLose);
	}

	//------------------- Access methods -------------------

	// Get hazard if it is active or not (true or false respectively)
	// Makes use of Convert.ToInt32 which returns 1 when true and 0 when false.
	// If given hazard does not exist it will return -1
	public int GetHazardState(string hazardName) {
		if(!hazards.ContainsKey(hazardName))
			return -1;
		return Convert.ToInt32(hazards[hazardName]);
	}

	// Get button if it is pressed or not (true or false respectively)
	// Makes use of Convert.ToInt32 which returns 1 when true and 0 when false.
	// If given button does not exist it will return -1
	public int GetButtonState(string buttonName) {
		if(!hazards.ContainsKey(buttonName))
			return -1;
		return Convert.ToInt32(hazards[buttonName]);
	}

	// Returns which hazard the button has an effect on. 
	// If given button does not exist it will return an empty string ""
	public string ButtonAffectsWhichHazard(string buttonName) {
		if(!hazards.ContainsKey(buttonName))
			return "";
		return buttonAffects[buttonName];
	}

	// Returns Max duration time of hazard.
	// If given hazard does not exist it will return -1
	public float GetHazardDuration(string hazardName) {
		if(!hazardDuration.ContainsKey(hazardName))
			return -1.0f;
		return hazardDuration[hazardName];
	}

	// Returns current countdown time of hazard.
	// If given hazard does not exist it will return -1
	public float GetHazardCountDown(string hazardName) {
		if(!hazardCountDown.ContainsKey(hazardName))
			return -1.0f;
		return hazardCountDown[hazardName];
	}

	//------------------- Add/Remove methods -------------------

	// Adds a hazard, and its duration time in seconds as a 2nd parameter. 
	// Returns -1 when given hazard name already exists.
	public int AddHazard(string hazardName, float duration) {
		if(hazards.ContainsKey(hazardName))
			return -1;
		hazards.Add(hazardName, false);
		// max time duration of the hazard
		hazardDuration.Add(hazardName, duration);
		// initialize the countdown as the duration
		hazardCountDown.Add(hazardName, duration);
		return 0;
	}

	// Adds a button, and the hazard it affects as 2nd parameter.
	// Returns -1 when given buttonname already exists.
	public int AddButton(string buttonName, string buttonAffectsHazard) {
		if(buttons.ContainsKey(buttonName))
			return -1;
		buttons.Add(buttonName, false);
		buttonAffects.Add(buttonName, buttonAffectsHazard);
		return 0;
	}

	// Removes a hazard. Returns -1 when given hazard does not exists.
	public int RemoveHazard(string hazardName) {
		if(!hazards.ContainsKey(hazardName))
			return -1;
		hazards.Remove(hazardName);
		hazardDuration.Remove(hazardName);
		hazardCountDown.Remove(hazardName);
		return 0;
	}

	// Removes a button. Returns -1 when given button does not exists.
	public int RemoveButton(string buttonName) {
		if(!buttons.ContainsKey(buttonName))
			return -1;
		buttons.Remove(buttonName);
		buttonAffects.Remove(buttonName);
		return 0;
	}

	// Empties the failure list.
	public void ResetFailure() {
		failureList.Clear();
	}

	//------------------- Update method -------------------

	// Update is called once per frame
	void Update () {

		// If button is true/pressed and if corresponding hazard is running/exists, disable the hazard.
		foreach(KeyValuePair<string,bool> entry in buttons) {
			if(entry.Value && hazards[buttonAffects[entry.Key]]) {
				hazards[buttonAffects[entry.Key]] = false;
				hazardCountDown[buttonAffects[entry.Key]] = hazardDuration[buttonAffects[entry.Key]];
			}
		}

		// not really accurate timekeeping, gotta find out exact time for seconds per tick etc.?
		if((lastTime + 1.0f) <= Time.time) {
			foreach(KeyValuePair<string,bool> entry in hazards) {
				if(entry.Value) {
					if(hazardCountDown[entry.Key] >= 1.0f)
						hazardCountDown[entry.Key] -= 1.0f;
					else if(hazardCountDown[entry.Key] < 1.0f) {
						failureList.Add(entry.Key);
						hazardCountDown[entry.Key] = hazardDuration[entry.Key];
					}
				}
			}
			lastTime = Time.time;
		}
	}
}
