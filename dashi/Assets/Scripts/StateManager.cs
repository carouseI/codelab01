using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    State currentState; //variable

    // Update is called once per frame
    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState(); //variable; ? = if not null, run current state, if null = ignore

        if(nextState != null)
        {
            SwitchToTheNextState(nextState); //switch to next state
        }
    }

    private void SwitchToTheNextState(State nextState)
    {
        currentState = nextState; //switch state above to state passing in
    }
}
