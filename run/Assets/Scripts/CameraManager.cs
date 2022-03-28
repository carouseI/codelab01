using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform targetTransform; //object camera will follow, after every frame is processed
    private Vector3 cameraFollowVelocity = Vector3.zero; //camera follow speed

    public float cameraFollowSpeed = 0.2f; //float for smooth time

    private void Awake()
    {
        targetTransform = FindObjectOfType<PlayerManager>().transform; //find player manager
    }

    public void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp
            (transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed); //smoothDamp = move smth softly between 1 location to another, usually used for in-game camera; targetPos = current camera position, targetTransform = player position
        transform.position = targetPosition; //set to new position
    }
}
