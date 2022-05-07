using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask;

    RaycastHit hitInfo;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if(Physics.Raycast(ray, out RaycastHit hitInfo, 20f, layerMask, QueryTriggerInteraction.Ignore)) //set raycast
        {
            Debug.Log("Hit something"); //show msg when collision
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red); //draw ray, ref when hit
        }
        else
        {
            Debug.Log("Hit nothing"); //show msg when no collision
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.green); //draw ray, green when nothing
        }
    }
}
