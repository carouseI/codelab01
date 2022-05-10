using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaleBlue
{
    public class PlayerManager : MonoBehaviour
    {
        InputManager inputManager;
        CameraManager cameraManager;
        PlayerLocomotion playerLocomotion;

        public void Awake()
        {
            inputManager = GetComponent<InputManager>(); //check for object with input manager comp
            cameraManager = FindObjectOfType<CameraManager>(); //find camera manager
            playerLocomotion = GetComponent<PlayerLocomotion>(); //check for object with locomotion comp
        }

        private void Update()
        {
            inputManager.HandleAllInput();
        }

        private void FixedUpdate()
        {
            playerLocomotion.HandleAllMovement();
        }

        private void LateUpdate() //lateUpdate = recommended when using fixedUpdate on rb, calls update after frame ended
        {
            cameraManager.HandleAllCameramovement(); //follow player
        }
    }
}