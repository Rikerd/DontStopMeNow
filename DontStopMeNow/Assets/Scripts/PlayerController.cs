using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float movementSpeed;
    public float jumpHeight;
    public LayerMask obstacleLayer;
    public LayerMask groundLayer;

    private float distance;
    private Rigidbody2D rb;
    private RaycastHit2D downRay;
    private RaycastHit2D upRay;
    private RaycastHit2D rightRay;

    // Use this for initialization
    void Start () {
        distance = 1.0f;
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.gravityScale = -rb.gravityScale;
        }

        if (Input.GetKeyDown(KeyCode.Z) && IsGrounded())
        {
            if (rb.gravityScale < 0)
            {
                rb.AddForce(Vector3.down * jumpHeight, ForceMode2D.Impulse);
            } else
            {
                rb.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);
            }
        }

        rightRay = Physics2D.Raycast(transform.position, Vector2.right, 0.6f, obstacleLayer);

        if (rightRay.collider != null)
        {
            Destroy(gameObject);
        }
    }

    bool IsGrounded()
    {
        downRay = Physics2D.Raycast(transform.position, Vector2.down, distance, groundLayer);
        upRay = Physics2D.Raycast(transform.position, Vector2.up, distance, groundLayer);

        if (downRay.collider != null || upRay.collider != null)
        {
            return true;
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            Destroy(gameObject);
        }
    }
}
