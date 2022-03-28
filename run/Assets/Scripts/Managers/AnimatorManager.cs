using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    Animator animator;
    int horizontal;
    int vertical;

    public Animator anim;

    private void Awake()
    {
        animator = GetComponent<Animator>(); //check for animator comp
        horizontal = Animator.StringToHash("Horizontal"); //refer to horizontal values in comp
        vertical = Animator.StringToHash("Vertical"); //refer to vertical values in comp
    }

    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
    {
        //animation snapping = if value is not quite walking or running + about to walk/run, code will snap to appropriate action + round values depending on distance
        float snappedHorizontal;
        float snappedVertical;
        #region SnappedHorizontal
        if (horizontalMovement > 0 && horizontalMovement < 0.55f) //if greater than 0 + less the 0.55
        {
            snappedHorizontal = 0.5f; //default to 0.5
        }
        else if (horizontalMovement > 0.55f) //if greater than 0.55
        {
            snappedHorizontal = 1; //default to 1
        }
        else if (horizontalMovement < 0 && horizontalMovement > -0.55f) //if less than 0 + greater than -0.55
        {
            snappedHorizontal = -0.5f; //default to -0.5
        }
        else if (horizontalMovement < -0.55f) //if less than -0.55
        {
            snappedHorizontal = -1; //default to -1
        }
        else
        {
            snappedHorizontal = 0; //default to 0
        }
        #endregion
        #region Snapped Vertical
        if (verticalMovement > 0 && verticalMovement < 0.55f) //if greater than 0 + less the 0.55
        {
            snappedVertical = 0.5f; //default to 0.5
        }
        else if (verticalMovement > 0.55f) //if greater than 0.55
        {
            snappedVertical = 1; //default to 1
        }
        else if (verticalMovement < 0 && verticalMovement > -0.55f) //if less than 0 + greater than -0.55
        {
            snappedVertical = -0.5f; //default to -0.5
        }
        else if (verticalMovement < -0.55f) //if less than -0.55
        {
            snappedVertical = -1; //default to -1
        }
        else
        {
            snappedVertical = 0; //default to 0
        }
        #endregion

        animator.SetFloat(horizontal, snappedHorizontal, 0.1f, Time.deltaTime); //set snapped horizontal animation; 0.1f = damp/blend time, transition between actions to smooth out motion
        animator.SetFloat(vertical, snappedVertical, 0.1f, Time.deltaTime); //set snapped vertical animation
    }

    public void PlayTargetAnimation(string targetAnim, bool isInteracting)
    {
        anim.applyRootMotion = isInteracting;
        anim.SetBool("isInteracting", isInteracting);
        anim.CrossFade(targetAnim, 0.2f);
    }
}