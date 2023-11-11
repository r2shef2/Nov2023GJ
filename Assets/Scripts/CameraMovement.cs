using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Vector3 target = player.position;
        target += offset;

        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);
    }
}
