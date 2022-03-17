using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.NPC;
using UnityEngine;

namespace Assets.Code.FSM.States
{
    [CreateAssetMenu(fileName ="PatrolState", menuName = "Unity-FSM/States/Patrol", order =2)] //add state to Unity asset window

    public class PatrolState: AbstractFSMState
    {
        NPCPatrolPoint[] _patrolPoints; //create set of patrol points; use existing patrol points/array
        int _patrolPointIndex; //maintain patrol point index, keep record of position


        public override void OnEnable()
        {
            base.OnEnable();
            _patrolPointIndex = -1; //set index to -1; check if index has tried anything yet
        }

        public override bool EnterState()
        {
            if(base.EnterState)) //check if base.EnterState is working
            {

            }

            return base.EnterState();
        }


        public override void UpdateState()
        {
            throw new NotImplementedException();
        }
    }
}