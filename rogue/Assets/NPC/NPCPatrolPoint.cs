using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.NPC
{
    public class NPCPatrolPoint : MonoBehaviour
    {
        [SerializeField]
        protected float debugDrawRadius = 1.0F;

        [SerializeField]
        protected float _connectivityRadius = 50F;

        List<NPCPatrolPoint> _connections;


        public void Start()
        {
            GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("PatrolPoint"); //get all waypoint objects in scene

            _connections = new List<NPCPatrolPoint>(); //create waypoint reference list

            for(int i = 0; i < allWaypoints.Length; i++) //check for waypoint connection
            {
                NPCPatrolPoint nextWaypoint = allWaypoints[i].GetComponent<NPCPatrolPoint>();

                if(nextWaypoint != null) //if not null
                {
                    if(Vector3.Distance(this.transform.position, nextWaypoint.transform.position) <= _connectivityRadius && nextWaypoint)
                    {
                        _connections.Add(nextWaypoint);
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
