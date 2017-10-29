using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
    public GameObject menu;

    void Awake()
    {
        menu = GameObject.Find("Pause Menu");
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

    public void Pause()
    {
        if (menu.activeInHierarchy == false)
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            menu.SetActive(false);
            Time.timeScale = 1;
        }
    }

}
