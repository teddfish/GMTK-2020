using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingScript : MonoBehaviour
{
    [SerializeField]
    float speed;
    float distance = 0.5f;
    bool movingRight = true;

    [SerializeField]
    Transform groundDetection;

    [SerializeField]
    GameObject player;
    bool playerDetected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > this.transform.position.x)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            movingRight = true;
        }
        else if(playerDetected && player.transform.position.x < this.transform.position.x)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }


        RaycastHit2D ground = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (ground.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
           

        //print(playerDetected);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerDetected = true;
        }
    }
}
