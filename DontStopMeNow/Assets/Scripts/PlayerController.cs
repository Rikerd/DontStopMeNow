using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpHeight;
    public LayerMask obstacleLayer;
    public LayerMask groundLayer;
    public float fadeSpeed;

    private bool playerDead;
    private float distance = 0.6f;
    private Rigidbody2D rb;
    private RaycastHit2D downRay;
    private RaycastHit2D upRay;
    private RaycastHit2D topRightRay;
    private RaycastHit2D botRightRay;
    private SpriteRenderer sprite;
    public float direction;

    // Use this for initialization
    void Start () {
        distance = 1.0f;
        direction = 1.0f;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {

        checkObstacle();

        bool grounded = isGrounded();

        if (!playerDead)
        {
            direction = (rb.gravityScale > 0) ? 1 : -1;

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && grounded)
            {
                rb.AddForce(Vector3.up * jumpHeight * direction, ForceMode2D.Impulse);
            }

            if ((Input.GetKeyDown(KeyCode.Tab) || Input.GetMouseButtonDown(1)) && grounded)
            {
                rb.gravityScale = -rb.gravityScale;
            }
        }
        else
        {
            StartCoroutine(Fade());
        }
    }

    void checkObstacle()
    {
        topRightRay = Physics2D.Raycast(transform.position + new Vector3(0f, 0.4f, 0f), Vector2.right, 0.6f, obstacleLayer);
        botRightRay = Physics2D.Raycast(transform.position - new Vector3(0f, 0.4f, 0f), Vector2.right, 0.6f, obstacleLayer);

        if (topRightRay.collider != null || botRightRay.collider != null)
        {
            playerDeath();
        }
    }

    bool isGrounded()
    {
        downRay = Physics2D.Raycast(transform.position, Vector2.down, distance, groundLayer);
        upRay = Physics2D.Raycast(transform.position, Vector2.up, distance, groundLayer);
        
        if (downRay.collider != null && direction == 1) {
            return true;
        }
            
        if (upRay.collider != null && direction == -1)
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
        rb.velocity = Vector2.zero;
        GetComponent<ParticleSystem>().Play();
        GetComponent<AudioSource>().Play();
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
