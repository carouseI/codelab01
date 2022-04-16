using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask;

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 20f, layerMask)) //set raycast
        {
            Debug.Log("Hit something"); //show msg when collision
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red); //draw ray, ref when hit
        }
        else
        {
            Debug.Log("Hit nothing"); //show msg when no collision
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.green); //draw ray, green when nothing
        }
    }
}
