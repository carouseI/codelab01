using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;

    public Vector2 movementInput; //vector2 = store info on 2 axis; up/down, left/right 
    public float verticalInput;
    public float horizontalInput;

    private void OnEnable()
    {
        if(playerControls == null) //if null
        {
            playerControls = new PlayerControls(); //use new control setup

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>(); //when key is hit, record movement to movementInput variable

        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable(); //turn off player controls when gameObject is disabled
    }

    public void HandleAllInput()
    {
        HandleMovementInput();
        //add, for future ref
        //HandleJumpingInput
        //HandleActionInput
    }
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y; //give value of movement input on y-axis, up/down
        horizontalInput = movementInput.x; //left: -1, right: +1, nothing = 0
    }
}
