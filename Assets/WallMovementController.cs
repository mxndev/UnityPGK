using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovementController : MonoBehaviour {
	float initialPosX;

	// Use this for initialization
	void Start () {
		initialPosX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x - initialPosX < 100) {
			transform.Translate (-3.0f * Time.deltaTime, 0, 0);
		}
	}
}
                                           