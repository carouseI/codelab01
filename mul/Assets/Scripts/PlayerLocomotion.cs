using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mul
{
    public class PlayerLocomotion : MonoBehaviour
    {
        InputManager inputManager;

        Vector3 moveDirection; //direction of player movement
        Transform cameraObject;
        Rigidbody playerRigidbody;


        [HideInInspector]
        public Transform myTransform;

        public float movementSpeed = 7; //set movement speed
        public float rotationSpeed = 15; //set rotation speed

        public void Awake()
        {
            inputManager = GetComponent<InputManager>(); //check for input manager comp
            playerRigidbody = GetComponent<Rigidbody>(); //check for rb comp
            cameraObject = Camera.main.transform; //scan for object tagged as main camera
        }

        public void HandleAllMovement()
        {
            HandleMovement();
            HandleRotation();
        }

        private void HandleMovement()
        {
            moveDirection = cameraObject.forward * inputManager.verticalInput; //movement input in camera direction * vertical input
            moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput; //move left/right based on horizont input + camera direction
            moveDirection.Normalize(); //keep vector direction, change length to 1
            moveDirection.y = 0; //stop player from walking in air
            moveDirection = moveDirection * movementSpeed; //calculate, direction * speed

            Vector3 movementVelocity = moveDirection; //store speed and direction info
            playerRigidbody.velocity = movementVelocity; //move player based on calculations
        }

        private void HandleRotation()
        {
            Vector3 targetDirection = Vector3.zero; //default to zero on all values

            targetDirection = cameraObject.forward * inputManager.verticalInput; //set player to always facing forward/running direction
            targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput; //direction + camera * horizontal input
            targetDirection.Normalize(); //search for direction of rotation based on input
            targetDirection.y = 0; //set to 0

            if (targetDirection == Vector3.zero)
                targetDirection = transform.forward; // keep rotatio at looking position upon stopping

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection); //quaternion = calculate rotation; look to target direction
            Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); //slerp = rotation between point A + B

            transform.rotation = playerRotation; //set player rotation
        }
    }
}