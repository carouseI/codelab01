using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code
{
    public class ConnectedWaypoint : Waypoint
    {
        [SerializeField]
        protected float _connectivityRadius = 50f;

        List<ConnectedWaypoint> _connections;


        public void Start()
        {
            //grad all waypoint objects in scene
            GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

            //create waypoint list for future reference
            _connections = new List<ConnectedWaypoint>();

            //check if connected waypoint
            for(int i = 0; i < allWaypoints.Length; i++)
            {
                ConnectedWaypoint nextWaypoint = allWaypoints[i].GetComponent<ConnectedWaypoint>();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}