using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Run
{
    public class CameraHandler : MonoBehaviour
    {
        public Transform targetTransform; //camera target position
        public Transform cameraTransform; //camera position
        public Transform cameraPivotTransform; //rotation point
        private Transform myTransform; //game object position
        private Vector3 cameraTransformPosition; //vector position of camera
        private LayerMask ignoreLayers;

        public static CameraHandler singleton;

        public float lookSpeed = 0.1f; //set look speed
        public float followSpeed = 0.1f; //set follow speed
        public float pivotSpeed = 0.03f; //set rotation speed

        private float defaultPosition; //default position
        private float lookAngle; //angle
        private float pivotAngle; //rotation
        public float minimumPivot = -35; //min turn
        public float maximumPivot = 35; //max turn

        private void Awake()
        {
            singleton = this;
            myTransform = transform; //game object transform
            defaultPosition = cameraTransform.localPosition.z; //set default to z position
            ignoreLayers = ~(1 << 8 | 1 << 9 | 1 << 10); //ignore following layers
        }

        public void FollowTarget(float delta)
        {
            Vector3 targetPosition = Vector3.Lerp(myTransform.position, targetTransform.position, delta / followSpeed); //lerp between position + target position
            myTransform.position = targetPosition; //set to follow player/target position
        }

        public void HandleCameraRotation(float delta, float mouseXInput, float mouseYInput)
        {
            lookAngle += (mouseXInput * lookSpeed) / delta; //set vertical orientation
            pivotAngle -= (mouseYInput * pivotSpeed) / delta; //set rotation
            pivotAngle = Mathf.Clamp(pivotAngle, minimumPivot, maximumPivot); //clamp between pivot points

            Vector3 rotation = Vector3.zero; //reset
            rotation.y = lookAngle; //set y to vertical movement
            Quaternion targetRotation = Quaternion.Euler(rotation);
            myTransform.rotation = targetRotation; //set player rotation to target rotation

            rotation = Vector3.zero; //reset
            rotation.x = pivotAngle; //set x to pivot

            targetRotation = Quaternion.Euler(rotation); //set target rotation
            cameraPivotTransform.localRotation = targetRotation; //set rotation
        }
    }
}