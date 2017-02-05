using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DoorTeleport : MonoBehaviour {
	Vector3 playerPos;
	float offset;
	FirstPersonController player;

	// Use this for initialization
	void Start () {
		playerPos = new Vector3 ();
		offset = 50.0f;
		player = (FirstPersonController)FindObjectOfType(typeof(FirstPersonController));
	}
}


	// Update is called once per frame
	void Update () {
		playerPos = player.transform.position;
		if(player.transform.position )
	bool CheckPlayerInDoors(Vector3 playerPos, Vector3 doorPos)
	{
		if(((doorPos.x - playerPos.x <= offset) || (playerPos.x - doorPos.x >= offset)) && ((doorPos.y - playerPos.y <= offset) || (playerPos.x - doorPos.x >= offset)))
	}
}
