using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace run
{
    public class PlayerLocomotion : MonoBehaviour
    {

        Transform cameraObject;
        InputHandler inputHandler;
        Vector3 moveDirection;

        [HideInInspector]
        public Transform myTransform;

        [HideInInspector]
        public AnimatorHandler animatorHandler;

        public new Rigidbody rigidbody;
        public GameObject normalCamera;

        [Header("States")]
        [SerializeField]
        float movementSpeed = 5;

        [SerializeField]
        float rotationSpeed = 10;

        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>(); //check for rigidbody comp
            inputHandler = GetComponent<InputHandler>(); //check for input handler comp
            animatorHandler = GetComponentInChildren<AnimatorHandler>(); //get animator handler comp from player model under game obj
            cameraObject = Camera.main.transform; //check for camera position
            myTransform = transform;
            animatorHandler.Initialize(); //load on start
        }

        public void Update()
        {
            float delta = Time.deltaTime;

            inputHandler.TickInput(delta); //pass delta

            moveDirection = cameraObject.forward * inputHandler.vertical; //forward + vertical movement
            moveDirection += cameraObject.right * inputHandler.horizontal; //side + horizontal movement
            moveDirection.Normalize(); //normalise

            float speed = movementSpeed;
            moveDirection *= speed; //set speed + movement accordingly

            Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector); //find velocity = movement + vector
            rigidbody.velocity = projectedVelocity; //set velocity

            animatorHandler.UpdateAnimatorValues(inputHandler.moveAmount, 0); //update value when in motion

            if (animatorHandler.canRotate)
            {
                HandleRotation(delta); //enable character rotation
            }
        }

        #region Movement
        Vector3 normalVector;
        Vector3 targetPosition;

        private void HandleRotation(float delta) //pass delta
        {
            Vector3 targetDir = Vector3.zero;
            float moveOverride = inputHandler.moveAmount;

            targetDir = cameraObject.forward * inputHandler.vertical; //forward camera movement + vertical inputs
            targetDir += cameraObject.right * inputHandler.horizontal; //side camera movement + horizontal inputs

            targetDir.Normalize();
            targetDir.y = 0; //no movement on y-axis

            if (targetDir == Vector3.zero) //if target direction = vector 3
                targetDir = myTransform.forward; //set to forward position

            float rs = rotationSpeed;

            Quaternion tr = Quaternion.LookRotation(targetDir); //tr = target rotation
            Quaternion targetRotation = Quaternion.Slerp(myTransform.rotation, tr, rs * delta); //slerp betwee rotation, target + speed by delta

            myTransform.rotation = targetRotation;
        }

        #endregion
    }
}
