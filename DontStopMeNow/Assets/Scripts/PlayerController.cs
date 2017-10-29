﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpHeight;
    public LayerMask obstacleLayer;
    public LayerMask groundLayer;
    public float fadeSpeed;

    private bool playerDead;
    private float distance = 1;
    private Rigidbody2D rb;
    private RaycastHit2D downRay;
    private RaycastHit2D upRay;
    private RaycastHit2D topRightRay;
    private RaycastHit2D botRightRay;
    private SpriteRenderer sprite;
    private float direction;

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

        if (!playerDead)
        {
            if (Input.GetKeyDown(KeyCode.Tab) && isGrounded())
            {
                rb.gravityScale = -rb.gravityScale;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                direction = (rb.gravityScale > 0) ? direction : -direction;
                rb.AddForce(Vector3.up * jumpHeight * direction, ForceMode2D.Impulse);
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
