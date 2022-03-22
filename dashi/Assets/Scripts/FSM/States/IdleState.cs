using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.FSM.States
{
    [CreateAssetMenu(fileName = "IdleState", menuName = "Unity-FSM/States/Idle", order = 1)] //create instance of state in editor, add menu in Unity window for access

    public class IdleState : AbstractFSMState
    {
        [SerializeField]
        float _idleDuration = 3f; //time out, transition back out into other state after 3 sec of time

        float _totalDuration; //total time active


        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.IDLE;
        }

        public override bool EnterState() //call base implementation on abstract class
        {
            EnteredState = base.EnterState(); //enter state

            if (EnteredState)
            {
                Debug.Log("entered idle state"); //show debug msg
                _totalDuration = 0f; //set timer to 0
            }

            //EnteredState = true; //successfully entry
            return EnteredState; //return
        }

        public override void UpdateState() //no error detected with idle state; preventative measure, stops compiler from generating errors*
        {
            //throw new NotImplementedException(); //throw exception every frame update

            if (EnteredState)
            {
                _totalDuration += Time.deltaTime; //increment by delta time

                Debug.Log("updating idle state: " + _totalDuration + " seconds."); //show debug msg + print idle timer

                if (_totalDuration >= _idleDuration)//if passed idle duration
                {
                    _fsm.EnterState(FSMStateType.PATROL); //trigger fsm to enter state again + force patrol again
                }
            }
        }

        public override bool ExitState()
        {
            base.ExitState(); //call parent state

            Debug.Log("exiting idle state"); //show debug msg
            return true; //return
        }
    }
}