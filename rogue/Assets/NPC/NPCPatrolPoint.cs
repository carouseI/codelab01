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
        protected float debugDrawRadius = 1.0f; //set waypoint size

        [SerializeField]
        protected float _connectivityRadius = 50f; //set connectivity radius size

        List<NPCPatrolPoint> _connections; //waypoint list


        public void Start()
        {
            GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("PatrolPoint"); //get all waypoint objects in scene

            _connections = new List<NPCPatrolPoint>(); //create waypoint reference list

            for(int i = 0; i < allWaypoints.Length; i++) //check for waypoint connection
            {
                NPCPatrolPoint nextWaypoint = allWaypoints[i].GetComponent<NPCPatrolPoint>(); //pull from list

                if(nextWaypoint != null) //if not null
                {
                    if(Vector3.Distance(this.transform.position, nextWaypoint.transform.position) <= _connectivityRadius && nextWaypoint) //if distance between this + next point is less/equal to connectivity radius + next point
                    {
                        _connections.Add(nextWaypoint); //go to the next point
                    }
                }
            }
        }
    }
}
