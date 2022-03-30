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

        public float rotationSpeed = 15; //rotation speed

        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>(); //check for enemy manager comp
            enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>(); //check for enemy animator manager comp
            navMeshAgent = GetComponentInChildren<NavMeshAgent>(); //check for navmesh
            enemyRigidBody = GetComponent<Rigidbody>(); //check for rb
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
                CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>(); //check for character stat comp

                if(characterStats != null) //if not null
                {
                    Vector3 targetDirection = characterStats.transform.position - transform.position; //set target direction
                    float viewableAngle = Vector3.Angle(targetDirection, transform.forward); //calculate angle

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
            distanceFromTarget = Vector3.Distance(currentTarget.transform.position, transform.position); //calculate distance from target
            float viewableAngle = Vector3.Angle(targetDirection, transform.forward); //find angle between where player is looking + where the target is

            if (enemyManager.isPerformingAction) //if performing action
            {
                enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime); //set movement to 0
                navMeshAgent.enabled = false; //set to false
            }
            else
            {
                if(distanceFromTarget > stoppingDistance) //distance from target is greater
                {
                    enemyAnimatorManager.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime); //set to 1
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
            if (enemyManager.isPerformingAction) //rotate manually if attacked
            {
                Vector3 direction = currentTarget.transform.position - transform.position; //set direction to current target - current position
                direction.y = 0; //set y to 0
                direction.Normalize(); //reset

                if(direction == Vector3.zero) //if direction is zero
                {
                    direction = transform.forward; //move forward
                }

                Quaternion targetRotation = Quaternion.LookRotation(direction); //target is in look direction
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed / Time.deltaTime); //set rotation
            }
            else //rotate with pathfinding, navmesh when chased
            {
                Vector3 relativeDirection = transform.InverseTransformDirection(navMeshAgent.desiredVelocity); //[check documentation]**
                Vector3 targetVelocity = enemyRigidBody.velocity; //set speed

                navMeshAgent.enabled = true; //set to true, when in use
                navMeshAgent.SetDestination(currentTarget.transform.position); //set destination
                enemyRigidBody.velocity = targetVelocity; //set speed
                transform.rotation = Quaternion.Slerp(transform.rotation, navMeshAgent.transform.rotation, rotationSpeed / Time.deltaTime); //set rotation
            }
        }
    }
}
