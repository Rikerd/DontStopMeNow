using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpHeight;
    public LayerMask obstacleLayer;
    public LayerMask groundLayer;
    public float fadeSpeed;

    private bool playerDead;
    private float distance;
    private Rigidbody2D rb;
    private RaycastHit2D downRay;
    private RaycastHit2D upRay;
    private RaycastHit2D rightRay;
    private bool startFade;
    private SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        distance = 1.0f;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        checkObstacle();

        if (Input.GetKeyDown(KeyCode.Tab) && IsGrounded() && !playerDead)
        {
            rb.gravityScale = -rb.gravityScale;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !playerDead)
        {
            if (rb.gravityScale < 0)
            {
                rb.AddForce(Vector3.down * jumpHeight, ForceMode2D.Impulse);
            } else
            {
                rb.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);
            }
        }

        if (startFade)
        {
            StartCoroutine(Fade());
        }
    }

    void checkObstacle()
    {
        rightRay = Physics2D.Raycast(transform.position, Vector2.right, 0.6f, obstacleLayer);

        if (rightRay.collider != null)
        {
            playerDeath();
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
            playerDeath();
        }
    }

    private void playerDeath()
    {
        playerDead = true;
        rb.gravityScale = 0;
        startFade = true;
        GetComponent<ParticleSystem>().Play();
    }

    public bool isPlayerDead()
    {
        return playerDead;
    }

    IEnumerator Fade()
    {
        Color spriteColor;

        for (float f = 1f; f >= 0; f -= fadeSpeed)
        {
            spriteColor = sprite.color;
            spriteColor.a = f;
            sprite.color = spriteColor;

            yield return null;
        }
    }
}
