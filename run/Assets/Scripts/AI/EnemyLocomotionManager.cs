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
        public Rigidbody enemyRigidBody;

        public CharacterStats currentTarget;
        public LayerMask detectionLayer;

        public float distanceFromTarget; //distance away
        public float stoppingDistance = 1f; //minimum distance to stop

        public float rotationSpeed = 15;

        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
            enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
            navMeshAgent = GetComponentInChildren<NavMeshAgent>();
            enemyRigidBody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            navMeshAgent.enabled = false; //disable at start
            enemyRigidBody.isKinematic = false; //set kinematic rb to false
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
                else if(distanceFromTarget <= stoppingDistance) //if distance from target is less than stopping distance
                {
                    enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime); //stop player
                }
            }

            HandleRotateTowardsTarget();
            navMeshAgent.transform.localPosition = Vector3.zero; //position
            navMeshAgent.transform.localRotation = Quaternion.identity; //rotation
        }

        private void HandleRotateTowardsTarget()
        {
            if (enemyManager.isPerformingAction) //rotate manually
            {
                Vector3 direction = currentTarget.transform.position - transform.position; //set direction to current target - current position
                direction.y = 0; //set y to 0
                direction.Normalize(); //reset

                if(direction == Vector3.zero)
                {
                    direction = transform.forward; //move forward
                }

                Quaternion targetRotation = Quaternion.LookRotation(direction); //target is in look direction
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed / Time.deltaTime); //set rotation
            }
            else //rotate with pathfinding, navmesh
            {
                Vector3 relativeDirection = transform.InverseTransformDirection(navMeshAgent.desiredVelocity); //[check documentation]**
                Vector3 targetVelocity = enemyRigidBody.velocity; //set speed

                navMeshAgent.enabled = true; //set to true, in use
                navMeshAgent.SetDestination(currentTarget.transform.position); //set destination
                enemyRigidBody.velocity = targetVelocity; //set speed
                transform.rotation = Quaternion.Slerp(transform.rotation, navMeshAgent.transform.rotation, rotationSpeed / Time.deltaTime); //set rotation
            }
        }
    }
}
