using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Run
{
    public class AnimatorHandler : AnimatorManager
    {
        PlayerManager playerManager;
        //InputHandler inputHandler;
        PlayerLocomotion playerLocomotion;
        int vertical;
        int horizontal;
        public bool canRotate;


        public void Initialize()
        {
            playerManager = GetComponentInParent<PlayerManager>();
            anim = GetComponent<Animator>();
            //inputHandler = GetComponentInParent<PlayerLocomotion>();
            vertical = Animator.StringToHash("Vertical");
            horizontal = Animator.StringToHash("Horizontal");
        }

        public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement, bool isSprinting)
        {
            #region Vertical
            //stuff
            #endregion

            #region Horizontal
            //more
            #endregion

            if (isSprinting)
            {
                v = 2;
                h = horizontalMovement;
            }

            anim.SetFloat(vertical, v, 0.1f, Time.deltaTime);
            anim.SetFloat(horizontal, h, 0.1f, Time.deltaTime);
        }

        public void CanRotate()
        {
            canRotate = true;
        }

        public void StopRotation()
        {
            canRotate = false;
        }

        public void EnableCombo()
        {
            anim.SetBool("canDoCombo", true);
        }

        public void DisableCombo()
        {
            anim.SetBool("canDoCombo", false);
        }


        private void OnAnimatorMove()
        {
            //if (playerManager.isInteracting == false)
            //    return;

            //float delta = Time.deltaTime;
            //playerLocomotion.rigidbody.drag = 0;
            //Vector3 deltaPosition = anim.deltaPosition;
            //deltaPosition.y = 0;
            //Vector3 velocity = deltaPosition / delta;
            //playerLocomotion.rigidbody.velocity = velocity;
        }
    }
}