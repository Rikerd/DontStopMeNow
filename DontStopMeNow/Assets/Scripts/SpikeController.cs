using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour {
    public float movementSpeed;
    public bool up;
    public LayerMask playerLayer;

    private GameObject player;
    private RaycastHit2D ray;
    private bool moving;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
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
        if (up)
        {
            ray = Physics2D.Raycast(transform.position, Vector2.up, 7f, playerLayer);
            if (ray.collider != null)
            {
                moving = true;
            }
        }
    }
}
