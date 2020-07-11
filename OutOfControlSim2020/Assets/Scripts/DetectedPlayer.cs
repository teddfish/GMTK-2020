using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedPlayer : MonoBehaviour
{
    public bool playerDetected;
    public bool onRight;
    public bool onLeft;

    Vector3 playerPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDetected = true;
            collision.transform.position = playerPos;
        }
    }

    private void Update()
    {
        if (playerDetected)
        {
            if(this.transform.position.x > playerPos.x)
            {
                onLeft = true;
            }
            else if (this.transform.position.x < playerPos.x)
            {
                onRight = true;
            }
        }
    }
}
