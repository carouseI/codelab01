using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public AttackState attackState;
    public bool isInAttackRange;

    public override State RunCurrentState()
    {
        if (isInAttackRange) //if in range
        {
            return attackState; //attack
        }
        else
        {
            return this; //keep running this state + approach
        }
    }
}
