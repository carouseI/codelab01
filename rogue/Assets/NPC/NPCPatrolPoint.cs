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

        // Start is called before the first frame update
        public void Start()
        {
            GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("PatrolPoint"); //get all waypoint objects in scene
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
