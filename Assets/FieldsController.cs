using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FieldsController : MonoBehaviour {
	GUIStyle style;
	FirstPersonController player;

	// Use this for initialization
	void Start () {
		player = (FirstPersonController)FindObjectOfType(typeof(FirstPersonController));
		style = new GUIStyle ();
		style.fontSize = 30;
		style.normal.textColor = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		if (CheckPlayerInField (player.transform.position, this.transform.position)) {
			double lossHP = 20 * Time.deltaTime;
			if ((player.hitPoints - lossHP) < 0) {
				player.hitPoints -= lossHP;
				player.transform.position = new Vector3 (234.0f, 1.0f, 111.0f);
				player.endMoveGame ();
			} else {
				player.hitPoints -= lossHP;
			}
		}
	}

	bool CheckPlayerInField(Vector3 playerPos, Vector3 fieldPos)
	{
		if((Mathf.Abs(fieldPos.x - playerPos.x) <= 2.5) && (Mathf.Abs(fieldPos.z - playerPos.z) <= 2.5) && (Mathf.Abs(fieldPos.y - playerPos.y) <= 1.5))
		{
			return true;
		}
		return false;
	}
}
