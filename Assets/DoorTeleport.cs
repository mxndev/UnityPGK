using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DoorTeleport : MonoBehaviour {
	float offset;
	FirstPersonController player;
	GUIStyle style;
	float endTime;
	bool renderBooks, renderWin;

	// Use this for initialization
	void Start () {
		offset = 0.8f;
		player = (FirstPersonController)FindObjectOfType(typeof(FirstPersonController));
		style = new GUIStyle ();
		style.fontSize = 30;
		style.normal.textColor = Color.white;
		renderBooks = false;
		renderWin = false;
	}


	// Update is called once per frame
	void Update () 
	{
		if(CheckPlayerInDoors(player.transform.position, this.transform.position)) {
			if ((Mathf.Round(this.transform.position.x) == 124) && (Mathf.Round(this.transform.position.z) == 221)) {
				player.transform.position = new Vector3 (230.0f, 1.0f, 95.0f);
				endTime = Time.time + 5;
			} else if ((Mathf.Round(this.transform.position.x) == 383) && (Mathf.Round(this.transform.position.z) == 109)) {
				player.transform.position = new Vector3 (314.0f, 1.3f, 164.0f);
				renderWin = true;
			} else {
				player.transform.position = new Vector3 (35.0f, 0.0f, 214.0f);
			}
		}
		if (endTime > Time.time) {
			renderBooks = true;
		} else {
			if (renderBooks) {
				renderBooks = false;
			}
		}
	}

	bool CheckPlayerInDoors(Vector3 playerPos, Vector3 doorPos)
	{
		if((Mathf.Abs(doorPos.x - playerPos.x) <= offset) && (Mathf.Abs(doorPos.z - playerPos.z) <= offset))
		{
			return true;
		}
		return false;
	}

	void OnGUI()
	{
		if (renderBooks)
		{
			GUI.Label (new Rect (Screen.width * 0.5f - 200.0f, Screen.height * 0.5f - 10f, 10, 20), "Zbierz wszystkie książki. Użyj E.", style);
		}
		if (renderWin)
		{
			GUI.Label (new Rect (Screen.width * 0.5f - 200.0f, Screen.height * 0.5f - 10f, 10, 20), "Gratulacje! Wygrałeś! Koniec gry :)", style);
		}
	}
}