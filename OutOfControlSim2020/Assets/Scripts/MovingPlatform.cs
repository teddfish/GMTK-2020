using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform iniPos;
    [SerializeField] Transform finPos;
    [SerializeField] float speed;
    [SerializeField] Transform startPos;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == iniPos.position)
        {
            nextPos = finPos.position;
        }
        else if (transform.position == finPos.position)
        {
            nextPos = iniPos.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(iniPos.position, finPos.position);
    }
}
