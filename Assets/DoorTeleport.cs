using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DoorTeleport : MonoBehaviour {
	float offset;
	FirstPersonController player;

	// Use this for initialization
	void Start () {
		offset = 0.8f;
		player = (FirstPersonController)FindObjectOfType(typeof(FirstPersonController));
	}


	// Update is called once per frame
	void Update () 
	{
		if (CheckPlayerInDoors(player.transform.position, this.transform.position))
		{
			float x = Mathf.Round (this.transform.position.x);
			float z = Mathf.Round (this.transform.position.z);
			if ((Mathf.Round(this.transform.position.x) == 124) && (Mathf.Round(this.transform.position.z) == 221)) {
				player.transform.position = new Vector3 (100.0f, 0.0f, 214.0f);
			} else {
				player.transform.position = new Vector3 (35.0f, 0.0f, 214.0f);
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
}