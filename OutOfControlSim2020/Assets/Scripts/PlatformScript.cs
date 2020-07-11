using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    PlatformEffector2D effector;
    float pressTimer;
    float rev = 180f;

    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            pressTimer = 0.5f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (pressTimer <= 0)
            {
                effector.rotationalOffset = rev;
                pressTimer = 0.5f;
            }
            else
            {
                pressTimer -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            effector.rotationalOffset = 0;
        }
    }
}
