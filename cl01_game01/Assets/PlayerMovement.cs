using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    //int wholeNumber = 16; //store whole number in variable
    //float decimalNumber = 4.56f; //floating point literal
    //string text = "blank"; //entry text
    //bool boolean = false; //check true/false conditions, executes based on condition

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log("Hello, world!");
        if (Input.GetButtonDown("Jump")) //GBD vs GKD, uses input system
        {
            rb.velocity = new Vector3(0, 14f, 0); //call rigidbody + add speed
        }
    }
}
