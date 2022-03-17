using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.FSM
{
    public class FiniteStateMachine: MonoBehaviour
    {
        [SerializeField] //expose in editor
        AbstractFSMState _startingState; //variable

        AbstractFSMState _currentState;

        public void Awake()
        {
            _currentState = null; //current state is null
        }

        public void Start()
        {
            if(_startingState != null) //if starting state is not null, enter state
            {
                EnterState(_startingState);
            }
        }

        public void Update()
        {
            if(_currentState != null) //if not null, update current state
            {
                _currentState.UpdateState();
            }
        }

        #region STATE MANAGEMENT

        public void EnterState(AbstractFSMState nextState) //pass in state of FSM
        {
            if(nextState == null) //if null, pull out of method
            {
                return;
            }

            _currentState = nextState;
            _currentState.EnterState();
        }

        #endregion
    }
}
