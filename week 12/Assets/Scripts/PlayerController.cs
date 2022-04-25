using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //rec: use fixed update when using physics/moving things

    [SerializeField] //inspector visibility without publicising, private variable accessible via inspector
    private float moveSpeed = 2.0f;

    Vector3 getInput;

    private void Update()
    {
        getInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //getAxis H = W, S (up/down); getAxis V = A, D (left/right)
        Debug.Log(getInput);
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = getInput * moveSpeed; //locate rb comp, set velocity

        Vector3 lookPos = new Vector3(
                transform.position.x + GetComponent<Rigidbody>().velocity.x,
                transform.position.y,
                transform.position.z + GetComponent<Rigidbody>().velocity.z
            );
        transform.LookAt(lookPos); //rotate object face to look at direction
    }
}
