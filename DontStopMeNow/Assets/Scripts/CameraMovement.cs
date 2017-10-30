using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour {
    public float movementSpeed;

    public bool completeTutorial = false;

    private PlayerController player;

	// Use this for initialization
	void Awake() {
        if (SceneManager.GetActiveScene().name != "Level 1" && SceneManager.GetActiveScene().name != "Level 2" && SceneManager.GetActiveScene().name != "Level 3")
        {
            completeTutorial = true;
        }

        player = GetComponentInChildren<PlayerController>();
	}
	
	// Update is called once per frame
	void Update() {
        if (!player.isPlayerDead() && completeTutorial)
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }
    }
}
