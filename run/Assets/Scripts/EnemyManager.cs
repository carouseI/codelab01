using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Run
{
    public class EnemyManager : MonoBehaviour
    {
        bool isPerformingAction; //tells when enemy is actually doing an action; i.e., moving, attacking

        [Header("A.I. Settings")]
        public float detectionRadius; //radius of enemy circle/detection zone

        //50/-50 = set fov to straight ahead
        public float maximumDetectionAngle = 50; //higher = greater dectection field of view
        public float minimumDetectionAngle = -50; //lower = greater detection field of view

        private void Awake()
        {
            
        }

        private void Update()
        {
            
        }

        private void HandleCurrentAction()
        {

        }
    }
}