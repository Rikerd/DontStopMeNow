﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour {
    public Vector3 offset;
    public float movementSpeed;
    public float direction = 1;
    public bool up;
    public LayerMask playerLayer;
    public bool horizontal;
    public float detectionRange; 

    private GameObject player;
    private RaycastHit2D ray;
    private bool moving;
    private bool horizontalMoving;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");

        direction = up ? direction : -direction;
	}
	
	// Update is called once per frame
	void Update () {
        checkPlayer();

        if (moving)
        {
            transform.Translate(Vector2.up * movementSpeed * direction * Time.deltaTime);
        }

        if (horizontalMoving)
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }
    }

    void checkPlayer()
    {
        if (horizontal)
        {
            ray = Physics2D.Raycast(transform.position, Vector2.left, detectionRange, playerLayer);
            if (ray.collider != null)
            {
                horizontalMoving = true;
            }
        }
        else
        {
            ray = Physics2D.Raycast(transform.position - offset, Vector2.up * direction, 10f, playerLayer);
            if (ray.collider != null && (player.GetComponent<Rigidbody2D>().gravityScale * direction < 0))
            {
                moving = true;
            }
        }
        
    }
}
