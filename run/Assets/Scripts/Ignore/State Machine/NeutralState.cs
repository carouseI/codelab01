using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralState : State
{
    public ChaseState chaseState; //desired state after player is found
    public bool canSeeThePlayer;


    public override State RunCurrentState()
    {
        if (canSeeThePlayer) //if player is detected
        {
            return chaseState; //enter chase state
        }
        else
        {
            return this;
        }
    }

}
