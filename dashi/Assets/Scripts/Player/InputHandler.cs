using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dashi
{
    public class InputHandler : MonoBehaviour
    {
        public float horizontal;
        public float vertical;
        public float moveAmount;
        public float mouseX;
        public float mouseY;

        PlayerControls inputActions;

        Vector2 movementInput;
        Vector2 cameraInput;

        public void OnEnable()
        {
            if (inputActions == null) //if null
            {
                inputActions = new PlayerControls(); //set new controls
                inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>(); //use movement inputs from vector 2
                inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>(); //use camera inputs from vector 2
            }

            inputActions.Enable(); //enable
        }

        private void OnDisable()
        {
            inputActions.Disable(); //disable
        }

        public void TickInput(float delta)
        {
            MoveInput(delta); //pass delta
        }

        private void MoveInput(float delta)
        {
            horizontal = movementInput.x; //movement on x-axis
            vertical = movementInput.y; //movment on y-axis
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical)); //clamp movement to horizontal + vertical only
            mouseX = cameraInput.x; //camera position on x-axis
            mouseY = cameraInput.y; //camera position on y-axis
        }
    }
}
