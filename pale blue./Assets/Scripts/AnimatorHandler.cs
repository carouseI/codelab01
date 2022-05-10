using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaleBlue
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
            playerManager = GetComponentInParent<PlayerManager>(); //find player manager comp
            anim = GetComponent<Animator>(); //find animator comp
            //inputHandler = GetComponentInParent<PlayerLocomotion>();
            vertical = Animator.StringToHash("Vertical"); //set vertical movement
            horizontal = Animator.StringToHash("Horizontal"); //set horizontal movement
        }

        public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement, bool isSprinting)
        {
            #region Vertical
            //clamp vertical movement
            float v = 0;

            if (verticalMovement > 0 && verticalMovement < 0.55f) // if greater than 0 + less than 0.55
            {
                v = 0.5f;
            }
            else if (verticalMovement > 0.55f) //if greater than 0.55
            {
                v = 1;
            }
            else if (verticalMovement < 0 && verticalMovement > -0.55f) //if less than 0 + greater tan -0.55
            {
                v = -0.5f;
            }
            else if (verticalMovement < -0.55f) //if less than -0.55
            {
                v = -1;
            }
            else
            {
                v = 0;
            }
            #endregion

            #region Horizontal
            //clamp horizontal movement
            float h = 0;

            if (horizontalMovement > 0 && horizontalMovement < 0.55f) // if greater than 0 + less than 0.55
            {
                h = 0.5f;
            }
            else if (horizontalMovement > 0.55f) //if greater than 0.55
            {
                h = 1;
            }
            else if (horizontalMovement < 0 && horizontalMovement > -0.55f) //if less than 0 + greater tan -0.55
            {
                h = -0.5f;
            }
            else if (horizontalMovement < -0.55f) //if less than -0.55
            {
                h = -1;
            }
            else
            {
                h = 0;
            }
            #endregion

            if (isSprinting)
            {
                //v = 2;
                //h = horizontalMovement;
            }

            //anim.SetFloat(vertical, v, 0.1f, Time.deltaTime);
            //anim.SetFloat(horizontal, h, 0.1f, Time.deltaTime);
        }

        #region //rotating, combo settings
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
        #endregion

        private void OnAnimatorMove() //temporarily commented out
        {
            //if (playerManager.isInteracting == false) //if not interacting
            //    return; //return

            //float delta = Time.deltaTime;
            //playerLocomotion.rigidbody.drag = 0; //set locomotion rb to 0
            //Vector3 deltaPosition = anim.deltaPosition; //set delta position to animator position
            //deltaPosition.y = 0; //set to 0
            //Vector3 velocity = deltaPosition / delta; //set speed
            //playerLocomotion.rigidbody.velocity = velocity; //set rb velocity
        }
    }
}