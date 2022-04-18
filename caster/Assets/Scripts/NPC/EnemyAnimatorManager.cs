using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caster
{
    public class EnemyAnimatorManager : AnimatorManager
    {
        EnemyLocomotionManager enemyLocomotionManager;

        private void Awake()
        {
            anim = GetComponent<Animator>(); //find animator comp
            enemyLocomotionManager = GetComponentInParent<EnemyLocomotionManager>(); //find loco comp in parent
        }

        private void OnAnimatorMove()
        {
            float delta = Time.deltaTime;
            enemyLocomotionManager.enemyRigidBody.drag = 0; //recenter model when animator plays with root motion
            Vector3 deltaPosition = anim.deltaPosition; //set animation position
            deltaPosition.y = 0; //set to 0
            Vector3 velocity = deltaPosition / delta; //calculate speed
            enemyLocomotionManager.enemyRigidBody.velocity = velocity; //set speed
        }
    }
}