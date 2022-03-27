using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;

    public void Awake()
    {
        inputManager = GetComponent<InputManager>(); //check for object with input manager comp
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
}
