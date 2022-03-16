using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


//waypoint subclass
namespace Assets.Code
{
    public class ConnectedWaypoint : Waypoint
    {
        [SerializeField]
        protected float _connectivityRadius = 50f; //added connectivity radius, set to to 50 units

        List<ConnectedWaypoint> _connections; //maintain own active list of waypoints to connect to


        public void Start()
        {
            //grad all waypoint objects in scene
            GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint"); //find all game objects with waypoint tag

            //create waypoint list for future reference
            _connections = new List<ConnectedWaypoint>();

            //check if connected waypoint
            for(int i = 0; i < allWaypoints.Length; i++)
            {
                ConnectedWaypoint nextWaypoint = allWaypoints[i].GetComponent<ConnectedWaypoint>(); //get connected waypoint comp

                if(nextWaypoint != null) //check if comp is attached; if not null
                {
                    if(Vector3.Distance(this.transform.position, nextWaypoint.transform.position) <= _connectivityRadius && nextWaypoint != this) //if distance between this position + next waypoint position = less/equal to connectivity radius; check that next waypoint does not equal this
                    {
                        _connections.Add(nextWaypoint); //add to index
                    }
                }
            }
        }

        public override void OnDrawGizmos()
        {
            //base.OnDrawGizmos(); //autofill, check later

            Gizmos.color = Color.red; //set gizmo colour
            Gizmos.DrawWireSphere(transform.position, debugDrawRadius); //set gizmo to sphere

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _connectivityRadius);
        }

        public ConnectedWaypoint NextWaypoint(ConnectedWaypoint previousWaypoint)
        {
            if(_connections.Count == 0) //if no waypoints
            {
                Debug.LogError("Insufficient waypoint count"); //show this msg
                return null; //return null
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }

}