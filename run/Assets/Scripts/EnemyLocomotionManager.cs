using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Run
{
    public class EnemyLocomotionManager : MonoBehaviour
    {
        EnemyManager enemyManager;
        EnemAnimatorManager enemyAnimatorManager;

        public CharacterStats currentTarget;
        public LayerMask detectionLayer;

        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
        }

        public void HandleDetection() //detect when enemy spots player
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer); //only cast on detection layer, prevent from searching every object with collider

            for (int i = 0; i < colliders.Length; i++) //for every collider detected
            {
                CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();

                if(characterStats != null) //if not null
                {
                    Vector3 targetDirection = characterStats.transform.position - transform.position;
                    float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                    if(viewableAngle > enemyManager.minimumDetectionAngle && viewableAngle < enemyManager.maximumDetectionAngle) //character stat script is found on detection layer + within field of view
                    {
                        currentTarget = characterStats; //add to target list
                    }
                }
            }
        }

        public void HandleMoveToTarget()
        {
            Vector3 targetDirection = currentTarget.transform.position - transform.position; //find target direction
            float viewableAngle = Vector3.Angle(targetDirection, transform.forward); //find angle between where player is looking + where the target is

            if (enemyManager.isPerformingAction)
            {

            }
        }
    }
}
