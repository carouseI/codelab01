using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Code.FSM;
//using Assets.Code.FSM;
using Assets.Code.NPCCode;
using UnityEngine;
using UnityEngine.AI;

public enum ExecutionState //check if states are working + done executing
{
    NONE,
    ACTIVE,
    COMPLETED,
    TERMINATED,
};

public enum FSMStateType
{
    IDLE,
    PATROL,
};

public abstract class AbstractFSMState : ScriptableObject //doesn't need to be attached to game object to function
{
    protected NavMeshAgent _navMeshAgent; //store as protected variable
    protected NPC _npc; //store executing npc variable
    protected FiniteStateMachine _fsm;

    public ExecutionState ExecutionState { get; protected set; } //in-line property, only state can change execution state of state is
    public FSMStateType StateType { get; protected set; } //get = state type property; protected set = so each class can differentiate what type it is

    public bool EnteredState { get; protected set; } //can only be set internally


    public virtual void OnEnable()
    {
        ExecutionState = ExecutionState.NONE; //state not yet active, req state machine to set up and activate
    }

    internal void SetExecutingNPC(NPC npc)
    {
        throw new NotImplementedException();
    }

    internal void SetExecutingFSM(FiniteStateMachine finiteStateMachine)
    {
        throw new NotImplementedException();
    }

    //virtual = by default, any subclasses = can override
    public virtual bool EnterState() //enter state successfully without errors
    {
        bool successNavMesh = true; //value success = true
        bool successNPC = true;

        ExecutionState = ExecutionState.ACTIVE;

        //check if nav mesh agent exists
        successNavMesh = (_navMeshAgent != null); //if not null

        //check if executing agent exist
        //successNPC = (_npc != null); //if not null

        return successNavMesh & successNPC; //return boolean conjunction of both variables together; if both are true = successfull entry to state as far as FSM state is concerned
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
        if (navMeshAgent != null) //if not null
        {
            _navMeshAgent = navMeshAgent; //store variable
        }
    }

    //public virtual void SetExecutingFSM(FiniteStateMachine fsm)
    //{
    //    if (fsm != null) //if not null
    //    {
    //        _fsm = fsm;
    //    }
    //}

    //public virtual void SetExecutingNPC(NPC npc) //set executing agent on state
    //{
    //    if (npc != null) //if not null
    //    {
    //        _npc = npc;
    //    }
    //}
}