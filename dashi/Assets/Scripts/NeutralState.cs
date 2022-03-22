using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralState : State
{
    public override State RunCurrentState()
    {
        return this;
    }

}
