using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float movementSpeed;

    private PlayerController player;

	// Use this for initialization
	void Awake() {
        player = GetComponentInChildren<PlayerController>();
	}
	
	// Update is called once per frame
	void Update() {
        if (!player.isPlayerDead())
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }
    }
}
