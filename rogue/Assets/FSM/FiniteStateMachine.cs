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
