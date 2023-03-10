using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTarget;
    public float speedCam;
    public Vector3 offset;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerTarget.position + offset, speedCam * Time.deltaTime);
    }
}
