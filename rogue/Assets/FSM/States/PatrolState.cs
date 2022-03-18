using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.NPCCode;
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
            EnteredState = false; //return false out of enter state; assume failure from beginning
            if (base.EnterState()) //check if base.EnterState is working
            {
                //grab patrol points from player + store
                _patrolPoints = _npc.PatrolPoints; //patrol points = same as NPC points

                if(_patrolPoints == null || _patrolPoints.Length == 0) //patrol points sent are null or an empty collection
                {
                    Debug.LogError("PatrolState: Failed to grab patrol points from NPC"); //show debug msg
                }
                else
                {
                    if (_patrolPointIndex < 0)
                    {
                        _patrolPointIndex = UnityEngine.Random.Range(0, _patrolPoints.Length); //generate random patrol point upon first state entry
                    }
                    else
                    {
                        _patrolPointIndex = (_patrolPointIndex + 1) % _patrolPoints.Length; //modulos = calculate remainder relative to length of patrol points
                    }

                    SetDestination(_patrolPoints[_patrolPointIndex]); //set destination of patrol points @ patrol point index
                    EnteredState = true; //return
                }
            }

            return EnteredState; //return as true/false, only if destination is set successfully
        }

        public override void UpdateState()
        {
            //throw new NotImplementedException();

            //check if state entry was successfull
            if (EnteredState)
            {
                if(Vector3.Distance(_navMeshAgent.transform.position, _patrolPoints[_patrolPointIndex].transform.position) <= 1f) //use nav mesh agent as point of reference, compare to patrol point position; check if less than 1 float
                {
                    _fsm.EnterState(FSMStateType.IDLE);
                }
            }
        }

        private void SetDestination(NPCPatrolPoint destination)
        {
            if(_navMeshAgent != null && destination != null) //if nav mesh + destination are not null
            {
                _navMeshAgent.SetDestination(destination.transform.position); //set patrol point destination
            }
        }
    }
}