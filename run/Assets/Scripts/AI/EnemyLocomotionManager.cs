using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Run
{
    public class EnemyLocomotionManager : MonoBehaviour
    {
        EnemyManager enemyManager;
        EnemyAnimatorManager enemyAnimatorManager;
        NavMeshAgent navMeshAgent;

        public CharacterStats currentTarget;
        public LayerMask detectionLayer;

        public float distanceFromTarget; //distance away
        public float stoppingDistance = 0.5f; //minimum distance to stop

        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
            enemyAnimatorManager = GetComponent<EnemyAnimatorManager>();
            navMeshAgent = GetComponent<NavMeshAgent>();
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
            distanceFromTarget = Vector3.Distance(currentTarget.transform.position, transform.position);
            float viewableAngle = Vector3.Angle(targetDirection, transform.forward); //find angle between where player is looking + where the target is

            if (enemyManager.isPerformingAction) //if performing action
            {
                enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime); //set movement to 0
                navMeshAgent.enabled = false; //set to false
            }
            else
            {
                if(distanceFromTarget > stoppingDistance)
                {
                    enemyAnimatorManager.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
                }
            }
        }
    }
}
