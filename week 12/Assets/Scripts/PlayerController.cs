using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //rec: use fixed update when using physics/moving things

    [SerializeField] //inspector visibility without publicising, private variable accessible via inspector
    private float moveSpeed = 2.0f;

    private void FixedUpdate()
    {
        Vector3 getInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //getAxis H = W, S (up/down); getAxis V = A, D (left/right)
        Debug.Log(getInput);
        GetComponent<Rigidbody>().velocity = getInput * moveSpeed; //locate rb comp, set velocity
    }
}
