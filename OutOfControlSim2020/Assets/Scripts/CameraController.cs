using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float smoothSpeed = 0.1f;
    [SerializeField]
    Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 toPosition = target.position + offset;
        Vector3 velocity = Vector3.zero;
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, toPosition, ref velocity, smoothSpeed);

        transform.position = smoothPosition;
    }
}
