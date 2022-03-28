using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Run
{
    public class EnemyLocomotionManager : MonoBehaviour
    {
        EnemyManager enemyManager;

        LayerMask detectionLayer;

        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
        }

        public void HandleDetection() //detect when enemy spots player
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer); //only cast on detection layer, prevent from searching every object with collider

            for(int i = 0, i < colliders.length; i++) //for every collider detected
            {

            }
        }
    }
}
