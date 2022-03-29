using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code revamped
namespace Run
{
    public class PlayerLocomotion : MonoBehaviour
    {
        InputManager inputManager;

        Vector3 moveDirection; //direction of player movement
        Transform cameraObject;
        Rigidbody playerRigidbody;

        public float movementSpeed = 7; //set movement speed
        public float rotationSpeed = 15; //set rotation speed

        public void Awake()
        {
            inputManager = GetComponent<InputManager>(); //check for input manager comp
            playerRigidbody = GetComponent<Rigidbody>(); //check for rb comp
            cameraObject = Camera.main.transform; //scan for object tagged as main camera
        }

        public void HandleAllMovement()
        {
            HandleMovement();
            HandleRotation();
        }

        private void HandleMovement()
        {
            moveDirection = cameraObject.forward * inputManager.verticalInput; //movement input in camera direction * vertical input
            moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput; //move left/right based on horizont input + camera direction
            moveDirection.Normalize(); //keep vector direction, change length to 1
            moveDirection.y = 0; //stop player from walking in air
            moveDirection = moveDirection * movementSpeed; //calculate, direction * speed

            Vector3 movementVelocity = moveDirection; //store speed and direction info
            playerRigidbody.velocity = movementVelocity; //move player based on calculations
        }

        private void HandleRotation()
        {
            Vector3 targetDirection = Vector3.zero; //default to zero on all values

            targetDirection = cameraObject.forward * inputManager.verticalInput; //set player to always facing forward/running direction
            targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput; //direction + camera * horizontal input
            targetDirection.Normalize(); //search for direction of rotation based on input
            targetDirection.y = 0; //set to 0

            if (targetDirection == Vector3.zero)
                targetDirection = transform.forward; // keep rotatio at looking position upon stopping

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection); //quaternion = calculate rotation; look to target direction
            Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); //slerp = rotation between point A + B

            transform.rotation = playerRotation; //set player rotation
        }
    }
}

//namespace run
//{
//    public class PlayerLocomotion : MonoBehaviour
//    {

//        Transform cameraObject;
//        InputHandler inputHandler;
//        Vector3 moveDirection;

//        [HideInInspector]
//        public Transform myTransform;

//        [HideInInspector]
//        public AnimatorHandler animatorHandler;

//        public new Rigidbody rigidbody;
//        public GameObject normalCamera;

//        [Header("States")]
//        [SerializeField]
//        float movementSpeed = 5;

//        [SerializeField]
//        float rotationSpeed = 10;

//        // Start is called before the first frame update
//        void Start()
//        {
//            rigidbody = GetComponent<Rigidbody>(); //check for rigidbody comp
//            inputHandler = GetComponent<InputHandler>(); //check for input handler comp
//            animatorHandler = GetComponentInChildren<AnimatorHandler>(); //get animator handler comp from player model under game obj
//            cameraObject = Camera.main.transform; //check for camera position
//            myTransform = transform;
//            animatorHandler.Initialize(); //load on start
//        }

//        public void Update()
//        {
//            float delta = Time.deltaTime;

//            inputHandler.TickInput(delta); //pass delta

//            moveDirection = cameraObject.forward * inputHandler.vertical; //forward + vertical movement
//            moveDirection += cameraObject.right * inputHandler.horizontal; //side + horizontal movement
//            moveDirection.Normalize(); //normalise

//            float speed = movementSpeed;
//            moveDirection *= speed; //set speed + movement accordingly

//            Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector); //find velocity = movement + vector
//            rigidbody.velocity = projectedVelocity; //set velocity

//            animatorHandler.UpdateAnimatorValues(inputHandler.moveAmount, 0); //update value when in motion

//            if (animatorHandler.canRotate)
//            {
//                HandleRotation(delta); //enable character rotation
//            }
//        }

//        #region Movement
//        Vector3 normalVector;
//        Vector3 targetPosition;

//        private void HandleRotation(float delta) //pass delta
//        {
//            Vector3 targetDir = Vector3.zero;
//            float moveOverride = inputHandler.moveAmount;

//            targetDir = cameraObject.forward * inputHandler.vertical; //forward camera movement + vertical inputs
//            targetDir += cameraObject.right * inputHandler.horizontal; //side camera movement + horizontal inputs

//            targetDir.Normalize();
//            targetDir.y = 0; //no movement on y-axis

//            if (targetDir == Vector3.zero) //if target direction = vector 3
//                targetDir = myTransform.forward; //set to forward position

//            float rs = rotationSpeed;

//            Quaternion tr = Quaternion.LookRotation(targetDir); //tr = target rotation
//            Quaternion targetRotation = Quaternion.Slerp(myTransform.rotation, tr, rs * delta); //slerp betwee rotation, target + speed by delta

//            myTransform.rotation = targetRotation;
//        }

//        #endregion
//    }
//}
