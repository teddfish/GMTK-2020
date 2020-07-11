using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float jumpForce = 10f;
    float move;
    float jump;
    bool isOnGround = true;
    float fallMultiplier = 2f;

    bool lookingRight = true;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        if (!lookingRight && move > 0)
        {
            Turn();
        }
        else if(lookingRight && move < 0)
        {
            Turn();
        } */

        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            rb.velocity = Vector2.up * jumpForce;
            isOnGround = false;
        }
        print(jump);

        if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        if (!lookingRight && move > 0)
        {
            Turn();
        }
        else if (lookingRight && move < 0)
        {
            Turn();
        }
    }

    void Turn()
    {
        if (!lookingRight)
        {
            lookingRight = !lookingRight;
            Vector3 turner = transform.localScale;
            turner.x *= -1;
            transform.localScale = turner;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platforms"))
        {
            isOnGround = true;
        }
    }
}
