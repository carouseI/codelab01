using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace run
{
    public class AnimatorHandler : MonoBehaviour
    {
        public Animator anim;
        int vertical;
        int horizontal;
        public bool canRotate;

        public void Initialize()
        {
            anim = GetComponent<Animator>();
            vertical = Animator.StringToHash("Vertial");
            horizontal = Animator.StringToHash("Horizontal");
        }

        public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement)
        {
            #region Vertical
            //clamp vertical movement
            float v = 0;

            if(verticalMovement > 0 && verticalMovement < 0.55f) // if greater than 0 + less than 0.55
            {
                v = 0.5f;
            }
            else if(verticalMovement > 0.55f) //if greater than 0.55
            {
                v = 1;
            }
            else if(verticalMovement < 0 && verticalMovement > -0.55f) //if less than 0 + greater tan -0.55
            {
                v = -0.5f;
            }
            else if(verticalMovement < -0.55f) //if less than -0.55
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


            anim.SetFloat(vertical, v, 0.1f, Time.deltaTime);
            anim.SetFloat(horizontal, v, 0.1f, Time.deltaTime);
        }

        public void CanRotate()
        {
            canRotate = true;
        }

        public void StopRotation()
        {
            canRotate = false;
        }
    }
}
