using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI; //permission to access nav mesh agent

namespace Assets.Code.NPC
{
    [RequireComponent(typeof(NavMeshAgent))] //embedded rule; when instance is created, must have a nav mesh agent + finite state machine attached to same game object -- if not, add missing components

    public class NPC: MonoBehaviour
    {
        NavMeshAgent _navMeshAgent;

        public void Awake()
        {
            _navMeshAgent = this.GetComponent<NavMeshAgent>(); //this. = optional, gets autocorrect to kick in
        }

        public void Start()
        {

        }

        public void Update()
        {

        }
    }
}
