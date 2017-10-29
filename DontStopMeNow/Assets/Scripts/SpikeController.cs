using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour {
    public Vector3 offset;
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
            transform.Translate(Vector2.up * movementSpeed * direction * Time.deltaTime);
        }
    }

    void checkPlayer()
    {
        ray = Physics2D.Raycast(transform.position - offset, Vector2.up * direction, 10f, playerLayer);
        if (ray.collider != null && (player.GetComponent<Rigidbody2D>().gravityScale * direction < 0))
        {
            moving = true;
        }
    }
}
