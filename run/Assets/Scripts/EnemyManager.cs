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