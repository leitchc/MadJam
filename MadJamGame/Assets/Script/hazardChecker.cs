using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

// Checks if button is pressed(in true state) and if corresponding hazard is also running(in true state)
// it will set the corresponding hazard to false.
public class hazardChecker : MonoBehaviour {

	private static Dictionary<string, bool> hazards = new Dictionary<string, bool>();
	private static Dictionary<string, string> buttonAffects = new Dictionary<string, string>();
	private static Dictionary<string, bool> buttons = new Dictionary<string, bool>();

	private static hazardChecker hazardObj = null;
	public static hazardChecker Instance {get {return hazardObj;}}

    // Use this for initialization
    void Awake () {
        hazardObj = this;
    }

	//----------------------------- Check methods -------------------------

	// Checks if hazard exists in internal dictionary, true if it exist, false if it does not.
	public bool hazardExist(string hazardName) {
		return hazards.ContainsKey(hazardName);
	}

	// Checks if button exists in internal dictionary, true if it exist, false if it does not.
	public bool buttonExist(string buttonName) {
		return hazards.ContainsKey(buttonName);
	}

	//----------------------------- Access methods -------------------------

	// Get hazard if it is active or not (true or false respectively)
	// Makes use of Convert.ToInt32 which returns 1 when true and 0 when false.
	// If given hazard does not exist it will return -1
	public int getHazardState(string hazardName) {
		if(!hazards.ContainsKey(hazardName))
			return -1;
		return Convert.ToInt32(hazards[hazardName]);
	}

	// Get button if it is pressed or not (true or false respectively)
	// Makes use of Convert.ToInt32 which returns 1 when true and 0 when false.
	// If given button does not exist it will return -1
	public int getButtonState(string buttonName) {
		if(!hazards.ContainsKey(buttonName))
			return -1;
		return Convert.ToInt32(hazards[buttonName]);
	}

	// Returns which hazard the button has an effect on. 
	// If given button does not exist it will return an empty string ""
	public string buttonAffectsWhichHazard(string buttonName) {
		if(!hazards.ContainsKey(buttonName))
			return "";
		return buttonAffects[buttonName];
	}

	//-------------------------- Add/Remove methods -------------------------

	// Adds a hazard. Returns -1 when given hazard name already exists.
	public int addHazard(string hazardName) {
		if(hazards.ContainsKey(hazardName))
			return -1;
		hazards.Add(hazardName, false);
		return 0;
	}

	// Adds a button with the hazard it affects as 2nd parameter.
	// Returns -1 when given buttonname already exists.
	public int addButton(string buttonName, string buttonAffectsHazard) {
		if(buttons.ContainsKey(buttonName))
			return -1;
		buttons.Add(buttonName, false);
		buttonAffects.Add(buttonName, buttonAffectsHazard);
		return 0;
	}

	// Removes a hazard. Returns -1 when given hazard does not exists.
	public int removeHazard(string hazardName) {
		if(!hazards.ContainsKey(hazardName))
			return -1;
		hazards.Remove(hazardName);
		return 0;
	}

	// Removes a button. Returns -1 when given button does not exists.
	public int removeButton(string buttonName) {
		if(!buttons.ContainsKey(buttonName))
			return -1;
		buttons.Remove(buttonName);
		buttonAffects.Remove(buttonName);
		return 0;
	}

	//--------------------------- Update method-----------------------------------

	// Update is called once per frame
	void Update () {
		// If button is true/pressed and if corresponding hazard is running/exists, disable the hazard.
		foreach(KeyValuePair<string,bool> entry in buttons) {
			if(entry.Value && hazards[buttonAffects[entry.Key]])
				hazards[buttonAffects[entry.Key]] = false;
		}
	}
}
