using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;
using Assets.Code.NPCCode;

namespace Assets.Code.FSM
{
    public class FiniteStateMachine: MonoBehaviour
    {
        [SerializeField] //expose in editor
        AbstractFSMState _startingState; //variable
        AbstractFSMState _currentState;

        [SerializeField]
        List<AbstractFSMState> _validStates; //states to add to FSM for use
        Dictionary<FSMStateType, AbstractFSMState> _fsmStates; //store using dictionary

        public void Awake()
        {
            _currentState = null; //current state is null

            _fsmStates = new Dictionary<FSMStateType, AbstractFSMState>(); //set up states


            NavMeshAgent navMeshAgent = this.GetComponent<NavMeshAgent>(); //grab nav mesh for foreach
            NPC npc = this.GetComponent<NPC>(); //grab npc for foreach; attached to same game object as nav mesh

            foreach(AbstractFSMState state in _validStates) //iterate through each state in valid states list
            {
                state.SetExecutingFSM(this);
                state.SetExecutingNPC(npc);
                state.SetNavMeshAgent(navMeshAgent);
                _fsmStates.Add(state.StateType, state);
            }
        }

        public void Start()
        {
            if(_startingState != null) //if starting state is not null
            {
                EnterState(_startingState); //enter starting state
            }
        }

        public void Update()
        {
            if(_currentState != null) //if not null
            {
                _currentState.UpdateState(); //update current state
            }
        }

        #region STATE MANAGEMENT
        //block code out in corner

        public void EnterState(AbstractFSMState nextState) //pass in particular instance of an FSM state
        {
            if(nextState == null) //if null
            {
                return; //pull out of method
            }

            if(_currentState != null) //if not null
            {
                _currentState.ExitState(); //exit state
            }

            _currentState = nextState; //set current state to next state
            _currentState.EnterState(); //enter state
        }

        public void EnterState(FSMStateType stateType)
        {
            if (_fsmStates.ContainsKey(stateType)) //if dictionary contains key of parameter being passed in, i.e. idle/patrol
            {
                AbstractFSMState nextState = _fsmStates[stateType]; //grab fsm state/value from dictionary that corresponds with key

                EnterState(nextState); //enter next state
            }
        }

        #endregion
    }
}
