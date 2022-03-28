using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    AnimatorManager animatorManager;

    public Vector2 movementInput; //vector2 = store info on 2 axis; up/down, left/right 
    private float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>(); //check for animator manager comp
    }

    private void OnEnable()
    {
        if (playerControls == null) //if null
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
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput)); //abs = absolute, takes away sign in front of values, make negatives into positives; Mathf.Clamp01 = clamp between values of 0 + 1
        animatorManager.UpdateAnimatorValues(0, moveAmount); //0 = no movement on horizontal until strafing is used
    }
}
