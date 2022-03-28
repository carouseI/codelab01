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
            myTransform = transform; //game object transform
            defaultPosition = cameraTransform.localPosition.z;
            ignoreLayers = ~(1 << 8 | 1 << 9 | 1 << 10);
        }
    }
}