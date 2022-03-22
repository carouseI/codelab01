using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.FSM;
using UnityEngine;
using UnityEngine.AI; //permission to access nav mesh agent

namespace Assets.Code.NPCCode
{
    //[RequireComponent(typeof(NavMeshAgent), typeof(FiniteStateMachine))] //embedded rule; when instance is created, must have a nav mesh agent + finite state machine attached to same game object -- if not, add missing components; NPC pre-reqs

    public class NPC : MonoBehaviour
    {
        [SerializeField]
        NPCPatrolPoint[] _patrolPoints;

        NavMeshAgent _navMeshAgent;
        //FiniteStateMachine _finiteStateMachine; //attached instance here + required comps

        public void Awake()
        {
            _navMeshAgent = this.GetComponent<NavMeshAgent>(); //this. = optional, gets autocorrect to kick in
            //_finiteStateMachine = this.GetComponent<FiniteStateMachine>();
        }

        public void Start()
        {

        }

        public void Update()
        {

        }

        public NPCPatrolPoint[] PatrolPoints
        {
            get
            {
                return _patrolPoints; //return
            }
        }
    }
}