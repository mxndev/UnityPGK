using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BooksCollector : MonoBehaviour {
	float offset;
	FirstPersonController player;
	GUIStyle style;

	// Use this for initialization
	void Start () {
		offset = 1.5f;
		player = (FirstPersonController)FindObjectOfType(typeof(FirstPersonController));
		style = new GUIStyle ();
		style.fontSize = 30;
		style.normal.textColor = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		if (CheckPlayerInBook (player.transform.position, this.transform.position)) {
			if (Input.inputString == "e" || Input.inputString == "E") {
				player.numberOfBooks += 1;
				Destroy (this.gameObject);
			}
		}
	}

	bool CheckPlayerInBook(Vector3 playerPos, Vector3 bookPos)
	{
		if((Mathf.Abs(bookPos.x - playerPos.x) <= offset) && (Mathf.Abs(bookPos.z - playerPos.z) <= offset))
		{
			return true;
		}
		return false;
	}
}
