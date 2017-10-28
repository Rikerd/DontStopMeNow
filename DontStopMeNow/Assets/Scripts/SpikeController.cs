using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour {
    public float movementSpeed;
    public bool up;
    public LayerMask playerLayer;

    private GameObject player;
    private RaycastHit2D ray;
    private float direction = 1;
    private bool moving;

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
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        }
    }

    void checkPlayer()
    {
        ray = Physics2D.Raycast(transform.position, Vector2.up * direction, 7f, playerLayer);
        if (ray.collider != null)
        {
            moving = true;
        }
    }
}
