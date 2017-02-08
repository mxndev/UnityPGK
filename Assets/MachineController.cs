using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MachineController : MonoBehaviour {
	float offset;
	FirstPersonController player;
	GUIStyle style;
	float endTime, endTimeFalse;
	bool renderMachine, renderFalse;

	// Use this for initialization
	void Start () {
		offset = 1.5f;
		player = (FirstPersonController)FindObjectOfType(typeof(FirstPersonController));
		style = new GUIStyle ();
		style.fontSize = 30;
		style.normal.textColor = Color.white;
		renderMachine = false;
		renderFalse = false;
		endTime = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player.numberOfBooks >= 10) {
			if (CheckPlayerInMachine (player.transform.position, this.transform.position)) {
				if (Input.inputString == "e" || Input.inputString == "E") {
					player.transform.position = new Vector3 (276.0f, 1.0f, 102.5f);
					player.initializeMoveGame ();
				}
			}
		}

		if((player.numberOfBooks >= 10) && (endTime == 0)) {
			endTime = Time.time + 5;
		}
		if (endTime > Time.time) {
			renderMachine = true;
		} else {
			if (renderMachine) {
				renderMachine = false;
			}
		}

		if (player.hitPoints <= 0) {
			endTimeFalse = Time.time + 5;
			player.hitPoints = 100;
		}
		if (endTimeFalse > Time.time) {
			renderFalse = true;
		} else {
			if (renderFalse) {
				renderFalse = false;
			}
		}
	}

	bool CheckPlayerInMachine(Vector3 playerPos, Vector3 bookPos)
	{
		if((Mathf.Abs(bookPos.x - playerPos.x) <= offset) && (Mathf.Abs(bookPos.z - playerPos.z) <= offset))
		{
			return true;
		}
		return false;
	}

	void OnGUI()
	{
		if (renderMachine)
		{
			GUI.Label (new Rect (Screen.width * 0.5f - 200.0f, Screen.height * 0.5f - 10f, 10, 20), "Teraz możesz użyć maszyny.", style);
		}
		if (renderFalse)
		{
			GUI.Label (new Rect (Screen.width * 0.5f - 200.0f, Screen.height * 0.5f - 10f, 10, 20), "Przegrałeś! Spróbuj jeszcze raz.", style);
		}
	}
}
