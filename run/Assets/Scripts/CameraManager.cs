using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;

    public Transform targetTransform; //object camera will follow, after every frame is processed
    private Vector3 cameraFollowVelocity = Vector3.zero; //camera follow speed

    public float cameraFollowSpeed = 0.2f; //float for smooth time
    public float cameraLookSpeed = 2;
    public float cameraPivotSpeed = 2;

    public float lookAngle; //camera, up/down
    public float pivotAngle; //camera, left/right

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>(); //find input manager
        targetTransform = FindObjectOfType<PlayerManager>().transform; //find player manager
    }

    public void HandleAllCameramovement() //call all functionality from this function, instead of calling all individual functions on player manager
    {
        FollowTarget();
        RotateCamera();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp
            (transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed); //smoothDamp = move smth softly between 1 location to another, usually used for in-game camera; targetPos = current camera position, targetTransform = player position
        transform.position = targetPosition; //set to new position
    }

    private void RotateCamera()
    {
        lookAngle = lookAngle + (inputManager.cameraInputX * cameraLookSpeed);
        pivotAngle = pivotAngle - (inputManager.cameraInputY * cameraPivotSpeed);
    }
}
