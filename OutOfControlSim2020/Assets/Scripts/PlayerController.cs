using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float jumpForce = 10f;
    float move;
    float jump;
    bool isOnGround = true;
    [SerializeField]
    float fallMultiplier = 2f;
    [SerializeField]
    float fallSpeed = 10f;


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

    AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip teleportSound;
    public AudioClip coinSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        portals = GameObject.FindGameObjectsWithTag("Portals");
        playerAudio = GetComponent<AudioSource>();
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
            playerAudio.PlayOneShot(jumpSound, 1);
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

        //exiting the game
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        //{
        //    Teleport();
        //    rb.velocity = Vector2.up * jumpForce;
        //    isOnGround = false;
        //}

        //if (rb.velocity.y > 0)
        //{
        //    rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        //}
        //print(move);

        // to control the fall speed bug
        if (rb.velocity.magnitude > fallSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, fallSpeed);
        }

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
        int currentNumber = randomNum;

        playerAudio.PlayOneShot(teleportSound, 1);
        //print(randomNum);

        //int randomNum = Random.Range(0, portals.Length);

        //this.transform.position = portals[randomNum].transform.position;
        //print(randomNum);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectibles"))
        {
            playerAudio.PlayOneShot(coinSound, 0.8f);
        }
    }
}
