using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mul
{
    public class CameraManager : MonoBehaviour
    {
        InputManager inputManager;

        public Transform targetTransform; //object camera will follow, after every frame is processed
        public Transform cameraPivot; //object camera uses to pivot
        public Transform cameraTransform; //transform of actual camera object in scene

        public LayerMask collisionLayers; //things camera will collide with in environment

        private float defaultPosition; //camera default position

        private Vector3 cameraFollowVelocity = Vector3.zero; //camera follow speed
        private Vector3 cameraVectorPosition; //use vector3 to edit z position, cannot use transform

        #region //public floats
        public float cameraCollisionOffset = 0.2f; //big offset = big distance pushed away from object -- how much camera will jump off objects; keep low
        public float minimumCollisionOffset = 0.2f;
        public float cameraCollisionRadius = 2; //use for raycasting, keep small
        public float cameraFollowSpeed = 0.2f; //float for smooth time
        public float cameraLookSpeed = 2;
        public float cameraPivotSpeed = 2;

        public float lookAngle; //camera, up/down
        public float pivotAngle; //camera, left/right
        public float minimumPivotAngle = -35;
        public float maximumPivotAngle = 35;
        #endregion

        private void Awake()
        {
            inputManager = FindObjectOfType<InputManager>(); //find input manager
            targetTransform = FindObjectOfType<PlayerManager>().transform; //find player manager
            cameraTransform = Camera.main.transform; //camera position
            defaultPosition = cameraTransform.localPosition.z; //set default to camera position on z-axis
        }

        public void HandleAllCameramovement() //call all functionality from this function, instead of calling all individual functions on player manager
        {
            FollowTarget();
            RotateCamera();
            HandleCameraCollisions();
        }

        private void FollowTarget()
        {
            Vector3 targetPosition = Vector3.SmoothDamp
                (transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed); //smoothDamp = move smth softly between 1 location to another, usually used for in-game camera; targetPos = current camera position, targetTransform = player position
            transform.position = targetPosition; //set to new position
        }

        private void RotateCamera()
        {
            //moved up from y sect, just to be consistent with x sect + readability
            Vector3 rotation;
            Quaternion targetRotation;

            lookAngle = lookAngle + (inputManager.cameraInputX * cameraLookSpeed); //set camera orientation on x-axis
            pivotAngle = pivotAngle - (inputManager.cameraInputY * cameraPivotSpeed); //set camera orientation on y-axis
            pivotAngle = Mathf.Clamp(pivotAngle, minimumPivotAngle, maximumPivotAngle); //lock max + min rotation values

            rotation = Vector3.zero; //set vector zeroes on all positions
            rotation.y = lookAngle; //set y position to look angle
            targetRotation = Quaternion.Euler(rotation); //set rotation
            transform.rotation = targetRotation; //set target rotation

            rotation = Vector3.zero; //reset to 0
            rotation.x = pivotAngle; //set pivot angle
            targetRotation = Quaternion.Euler(rotation); //set rotation
            cameraPivot.localRotation = targetRotation; //local = object rotation, exclude rotation in worldspace
        }

        private void HandleCameraCollisions() //move camera if brought up to object
        {
            float targetPosition = defaultPosition; //set default position
            RaycastHit hit; //store info when raycast is used
            Vector3 direction = cameraTransform.position - cameraPivot.position; //set camera direction
            direction.Normalize(); //reset

            if (Physics.SphereCast //create invisible sphere around sphereCast starting point object 
                (cameraPivot.transform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPosition), collisionLayers)) //starting point coordinates
            {
                float distance = Vector3.Distance(cameraPivot.position, hit.point); //set distance
                targetPosition = -(distance - cameraCollisionOffset); //set position
            }

            if (Mathf.Abs(targetPosition) < minimumCollisionOffset) //if collision
            {
                targetPosition = targetPosition - minimumCollisionOffset; //calculate distance and set new position
            }

            cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 02f); //adjust z position
            cameraTransform.localPosition = cameraVectorPosition; //set position
        }
    }
}