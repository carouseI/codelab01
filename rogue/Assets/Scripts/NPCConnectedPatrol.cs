using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Code
{
    public class NPCConnectedPatrol : MonoBehaviour
    {
        //dictate whether agent waits on each  node
        [SerializeField]
        bool _patrolWaiting;

        [SerializeField]
        float _totalWaitTime = 3f; //

        [SerializeField]
        float _switchProbability = 0.2f;

        NavMeshAgent _navMeshAgent;
        ConnectedWaypoint _currentWaypoint;
        ConnectedWaypoint _previousWaypoint;

        bool _travelling;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}