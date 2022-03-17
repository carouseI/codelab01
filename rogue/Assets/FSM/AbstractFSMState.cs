using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ExecutionState //check if states are working + done executing
{
    NONE,
    ACTIVE,
    COMPLETED,
    TERMINATED,
};

public abstract class AbstractFSMState : ScriptableObject //doesn't need to be attached to game object to function
{
    protected NavMeshAgent _navMeshAgent; //store as protected variable

    public ExecutionState ExecutionState { get; protected set; } //in-line property, only state can change execution state of state is

    public virtual void OnEnable()
    {
        ExecutionState = ExecutionState.NONE; //state not yet active, req state machine to set up and activate
    }

    //virtual = by default, any subclasses = can override
    public virtual bool EnterState() //enter state successfully without errors
    {
        bool success = true; //value success = true
        ExecutionState = ExecutionState.ACTIVE;
        success = (_navMeshAgent != null); //if not null

        return success; //return
    }

    public abstract void UpdateState(); //in finite state machine, update current state active in machine; can restrain, monobehaviour = no restraint on tic
    //abstract = new state class, must write update method, can override existing enter/exit states

    public virtual bool ExitState() //exit state with proper configuration
    {
        ExecutionState = ExecutionState.COMPLETED;
        return true;
    }

    public virtual void SetNavMeshAgent(NavMeshAgent navMeshAgent) //pass instance of type navMeshAgent
    {
        if(navMeshAgent != null) //if not null
        {
            _navMeshAgent = navMeshAgent; //store variable
        }
    }
    
}
