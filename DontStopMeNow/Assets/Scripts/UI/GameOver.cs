using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public PlayerController player;
    public GameObject menu;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        menu = GameObject.Find("Game Over Menu");
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        menu.SetActive(player.isPlayerDead());
    }
}
