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

        float dirX = Input.GetAxisRaw("Horizontal"); //left: -1, right: +1
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);


        if (Input.GetButtonDown("Jump")) //GBD vs GKD, uses input system
        {
            rb.velocity = new Vector2(rb.velocity.x, 14f); //call rigidbody + add speed
        }
    }
}
