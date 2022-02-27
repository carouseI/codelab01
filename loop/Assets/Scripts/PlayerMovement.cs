using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, moveSpeed, 0);
        //}
       
        //move player with custom function
        Move(KeyCode.W, 0, moveSpeed);
        Move(KeyCode.S, 0, -moveSpeed);
        Move(KeyCode.A, -moveSpeed, 0);
        Move(KeyCode.D, moveSpeed, 0);

    }

    void Move(KeyCode key, float xMove, float yMove) //3 arguments = looking for x velocity (+) y velocity
    {
        if (Input.GetKey(key)) //if key pressed/hit
        {
            GetComponent<Rigidbody>().velocity = new Vector3(xMove, yMove, 0); //change game object velocity
        }
    }
}
