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


        //total wait time at each node
        [SerializeField]
        float _totalWaitTime = 3f; //


        //probability of switching direction
        [SerializeField]
        float _switchProbability = 0.2f;


        //private variables for base behaviour
        NavMeshAgent _navMeshAgent;
        ConnectedWaypoint _currentWaypoint;
        ConnectedWaypoint _previousWaypoint;


        bool _travelling;
        bool _waiting;
        float _waitTimer;
        int _waypointsVisited;


        // Start is called before the first frame update
        public void Start()
        {
            _navMeshAgent = this.GetComponent<NavMeshAgent>();

            if (_navMeshAgent == null) //if null
            {
                Debug.LogError("nav mesh agent comp not attached to " + gameObject.name); //show this msg
            }
            else
            {
                if (_currentWaypoint == null) //if no waypoint
                {
                    GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint"); //find all available waypoint objects in scene

                    if (allWaypoints.Length > 0) //if number of points is greater than 0
                    {
                        while (_currentWaypoint == null)
                        {
                            int random = UnityEngine.Random.Range(0, allWaypoints.Length); //set at random
                            ConnectedWaypoint startingWaypoint = allWaypoints[random].GetComponent<ConnectedWaypoint>(); //check if waypoint comp is attached

                            if (startingWaypoint != null) //if not null
                            {
                                _currentWaypoint = startingWaypoint; //set to current waypoint
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("failed to locate usable waypoints in scene"); //show this msg
                    }
                }

                SetDestination(); //set destination
            }

        }

        // Update is called once per frame
        public void Update()
        {
                if(_travelling && _navMeshAgent.remainingDistance <= 1.0f) //check if close to destination
                {
                    _travelling = false; //set to false
                    _waypointsVisited++; //increment visited waypoint, maintain account

                    if (_patrolWaiting) //if intending to wait
                    {
                        _waiting = true; //set to true
                        _waitTimer = 0f; //reset timer
                    }
                    else
                    {
                        SetDestination(); //set destination
                    }
                }

            if (_waiting) //if waiting
            {
                _waitTimer += Time.deltaTime; //increment timer by delta time
                if(_waitTimer >= _totalWaitTime) //if timer exceeds total time
                {
                    _waiting = false; //set to false

                    SetDestination(); //set destination
                }
            }
        }

        private void SetDestination()
        {
            if(_waypointsVisited > 0) //if visited waypoints are greater than 0
            {
                ConnectedWaypoint nextWaypoint = _currentWaypoint.NextWaypoint(_previousWaypoint); //call current waypoint to locate next waypoint, provide previous; maintain active reference to where it's been + where it's going
                _previousWaypoint = _currentWaypoint; //set previous to current
                _currentWaypoint = nextWaypoint; //set current to next
            }

            Vector3 targetVector = _currentWaypoint.transform.position; //set target vector off new waypoint
            _navMeshAgent.SetDestination(targetVector); //set destination in nav mesh
            _travelling = true; //set to true
        }

    }

}