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

    }
}
