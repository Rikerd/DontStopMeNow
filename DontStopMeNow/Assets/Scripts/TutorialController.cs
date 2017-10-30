using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour {
    private CameraMovement movement;
    private TutorialController tutorial;
    
	void Awake () {
        tutorial = GetComponent<TutorialController>();

        if (SceneManager.GetActiveScene().name != "Level 1" && SceneManager.GetActiveScene().name != "Level 2")
        {
            tutorial.enabled = false;
        }

        movement = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                movement.completeTutorial = true;
                tutorial.enabled = false;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            if(Input.GetKeyDown(KeyCode.Tab) || Input.GetMouseButtonDown(1))
            {
                movement.completeTutorial = true;
                tutorial.enabled = false;
            }
        }
	}
}
