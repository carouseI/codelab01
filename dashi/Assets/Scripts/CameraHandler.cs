using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dashi
{
    public class CameraHandler : MonoBehaviour
    {
        public Transform targetTransform; //target position
        public Transform cameraTransform; //current position
        public Transform cameraPivotTransform; //turn angle, rotation point
        private Transform myTransform; //game obj transform
        private Vector3 cameraTransformPosition; //camear transform
        private LayerMask ignoreLayers; //use for camera collision

        public static CameraHandler singleton;

        public float lookSpeed = 0.1f;
        public float followSpeed = 0.1f;
        public float pivotSpeed = 0.03f;

        private float defaultPosition;
        private float lookAngle;
        private float pivotAngle;
        public float minimumPivot = -35;
        public float maximumPivot = 35;


        private void Awake()
        {
            singleton = this;
            myTransform = transform; //transform variable = this object's tranform
            defaultPosition = cameraTransform.localPosition.z;
            ignoreLayers = ~(1 << 8 | 1 << 9 | 1 << 10); //ignore layers during camera collision
        }


        public void FollowTarget(float delta)
        {
            Vector3 targetPosition = Vector3.Lerp(myTransform.position, targetTransform.position, delta / followSpeed); //set camera to follow target transform position (player)
            myTransform.position = targetPosition; //set new position
        }

        public void HandleCameraRotation(float delta, float mouseXInput, float mouseYInput)
        {
            lookAngle += (mouseXInput * lookSpeed) / delta; //set look angle
            //pivotAngle -= (mouseYInput * pivotSpeed) / delta; //set pivot angle
            pivotAngle = Mathf.Clamp(pivotAngle, minimumPivot, maximumPivot); //clamp camera between 2 points of pivot, cannot go lower/higher than established angles

            Vector3 rotation = Vector3.zero;
            rotation.y = lookAngle; //set angle on y-axis (height)
            Quaternion targetRotation = Quaternion.Euler(rotation); //set rotation target
            myTransform.rotation = targetRotation;

            rotation = Vector3.zero;
            rotation.x = pivotAngle; //set pivot on x-axis (turn)

            targetRotation = Quaternion.Euler(rotation);
            cameraPivotTransform.localRotation = targetRotation; //set camera pivot
        }

    }
}
