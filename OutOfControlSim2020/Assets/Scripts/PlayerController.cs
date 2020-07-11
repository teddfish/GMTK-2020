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

    public Transform groundCheck;
    public float rad;
    public LayerMask groundGround;

    public GameObject[] portals;
    float inputWaitTimer = 2f;
    bool turnedLeft;
    bool turnedRight;
    Vector2 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        portals = GameObject.FindGameObjectsWithTag("Portals");
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        /*
        if (Input.GetKeyDown(KeyCode.K))
        {
            Teleport();
        }*/
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

        isOnGround = Physics2D.OverlapCircle(groundCheck.position, rad, groundGround);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            Teleport();
            rb.velocity = Vector2.up * jumpForce;
            isOnGround = false;
        }
        //print(jump);

        if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        //inputWaitTimer += Time.deltaTime;

        //if (transform.localScale.x > 0 && move < 0 && inputWaitTimer > 1)
        //{
        //    Teleport();
        //    inputWaitTimer = 0;
        //}
        //else if (transform.localScale.x < 0 && move > 0 && inputWaitTimer > 1)
        //{
        //    Teleport();
        //    inputWaitTimer = 0;
        //}
    }

    private void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (!lookingRight && move > 0)
        {
            Turn();
            Teleport();
        }
        else if (lookingRight && move < 0)
        {
            Turn();
            Teleport();
        }

        //print(move);
    }

    void Turn()
    {
        lookingRight = !lookingRight;
        Vector3 turner = transform.localScale;
        turner.x *= -1;
        transform.localScale = turner;
    }

    void Teleport()
    {
        int randomNum = Random.Range(0, portals.Length);

        this.transform.position = portals[randomNum].transform.position;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Collectibles"))
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}
}
