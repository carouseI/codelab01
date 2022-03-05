using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.FSM.States
{
    public class IdleState: AbstractFSMState
    {
        public override bool EnterState() //call base implementation on abstract class
        {
            base.EnterState();

            Debug.Log("entered idle state");

            return true;
        }

        public override void UpdateState() //no error detected with idle state; preventative measure, stops compiler from generating errors*
        {
            //throw new NotImplementedException(); //throw exception every fram update

            Debug.Log("updating idle state");
        }

        public override ExitState()
        {
            base.ExitState(); //call parent state

            Debug.Loge("exiting idle state");

            return true;
        }
    }
}
