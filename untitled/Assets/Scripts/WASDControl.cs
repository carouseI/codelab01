using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDControl : MonoBehaviour
{
    public float speed = 5.0f; //set speed value

    //Update called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //generate WASD movement

        transform.position += movement * speed * Time.deltaTime;


        float x = transform.position.x; 
        float y = transform.position.y;
        float z = transform.position.z;


        float lowerBoundaryX = 440.5f + transform.localScale.x * 0.5f;
        float lowerBoundaryZ = -10f + transform.localScale.z * 0.5f;
        float upperBoundaryX = 460.5f - transform.localScale.x * 0.5f;
        float upperBoundaryZ = 10f - transform.localScale.z * 0.5f;


        x = Mathf.Clamp(x, lowerBoundaryX, upperBoundaryX); //set MIN and MAX boundary values for the x axis

        z = Mathf.Clamp(z, lowerBoundaryZ, upperBoundaryZ); //set MIN and MAX boundary values for the z axis

        transform.position = new Vector3(x, y, z); //set new position


    }
    
    void OnTriggerEnter(Collider other) //setup collision event
    {
        if (other.gameObject.tag == "Enemy") //check if player collided with enemy
        {
            Destroy(other.gameObject); //destroy enemy when collision takes place

            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f); //increase player mass when collision takes place
        }
    }
}