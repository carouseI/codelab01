using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;

    public Vector2 movementInput; //vector2 = store info on 2 axis; up/down, left/right 

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
}
