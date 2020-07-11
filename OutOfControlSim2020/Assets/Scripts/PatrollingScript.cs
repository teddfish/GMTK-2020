using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingScript : MonoBehaviour
{
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    [SerializeField] float speed;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool left = GameObject.Find("PlayerDetector").GetComponent<DetectedPlayer>().onLeft;
        bool right = GameObject.Find("PlayerDetector").GetComponent<DetectedPlayer>().onRight;

        if (left)
        {
            nextPos = leftPos.position;
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
        else if (right)
        {
            nextPos = rightPos.position;
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
    }
}
