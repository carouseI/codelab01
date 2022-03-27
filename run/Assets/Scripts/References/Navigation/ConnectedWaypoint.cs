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
            for (int i = 0; i < allWaypoints.Length; i++)
            {
                ConnectedWaypoint nextWaypoint = allWaypoints[i].GetComponent<ConnectedWaypoint>(); //get connected waypoint comp

                if (nextWaypoint != null) //check if comp is attached; if not null
                {
                    if (Vector3.Distance(this.transform.position, nextWaypoint.transform.position) <= _connectivityRadius && nextWaypoint != this) //if distance between this position + next waypoint position = less/equal to connectivity radius; check that next waypoint does not equal this
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

            Gizmos.color = Color.yellow; //set connectivity radius colour to yellow
            Gizmos.DrawWireSphere(transform.position, _connectivityRadius); //add connectivity radiuses
        }

        public ConnectedWaypoint NextWaypoint(ConnectedWaypoint previousWaypoint) //check for other waypoint to reach; provide previous waypoint/location, prevent being sent back
        {
            if (_connections.Count == 0) //if no waypoints
            {
                Debug.LogError("Insufficient waypoint count"); //show this msg
                return null; //return null
            }
            else if (_connections.Count == 1 && _connections.Contains(previousWaypoint)) //if list is only 1 + the previous one, dead end
            {
                return previousWaypoint; //return
            }
            else
            {
                ConnectedWaypoint nextWaypoint; //find random point that isn't the previous one
                int nextIndex = 0; //create index

                do //run do while loop
                {
                    nextIndex = UnityEngine.Random.Range(0, _connections.Count); //generate random number between range of connections
                    nextWaypoint = _connections[nextIndex]; //set next waypoint to randomly selected item in list
                }
                while (nextWaypoint == previousWaypoint); //loop; guarantee next isn't the previous one

                return nextWaypoint; //return next waypoint if all checks out
            }
        }
    }
}