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
                if(_travelling & _navMeshAgent.remainingDistance <= 1.0f) //check if close to destination
                {
                    _travelling = false;
                    _waypointsVisited++;

                    if (_patrolWaiting) //if intending to wait
                    {
                        _waiting = true; //set to true
                    }
                }

            if (_waiting) //if waiting
            {
                _waitTimer += Time.deltaTime;
                if(_waitTimer >= _totalWaitTime)
                {
                    _waiting = false;

                    SetDestination();
                }

            }

        }

        private void SetDestination()
        {
            if(_waypointsVisited > 0)
            {
                ConnectedWaypoint nextWaypoint = _currentWaypoint.NextWaypoint(_previousWaypoint);
                _previousWaypoint = _currentWaypoint;
                _currentWaypoint = nextWaypoint;
            }

            Vector3 targetVector = _currentWaypoint.transform.position;
            _navMeshAgent.SetDestination(targetVector);
            _travelling = true; //set to true
        }


    }

}