using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private float characterVelocityX = 5f;
    private float characterVelocityZ = 5f;
    private Vector3 movementDirection;
    private Vector3 movementPerSecond;

    public float changeTime = 3.0f;

    public bool hitWall = false;

    public float direction = 0.0f;

    public float boarderLeft;
    public float boarderRight;

    public float speedLeft;
    public float speedRight;


    int rand;

    void Start()
    {

        characterVelocityX = Random.Range(-3, 3); //set character speed
        characterVelocityZ = Random.Range(-3, 3);
    }


    void Update()
    {

        transform.position = new Vector3(transform.position.x + (characterVelocityX * Time.deltaTime), transform.position.y, transform.position.z + (characterVelocityZ * Time.deltaTime));


        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;


        float lowerBoundaryX = 440.5f + transform.localScale.x * 0.5f; //set player position back by 0.5 when colliding with lower boundary MIN value
        float lowerBoundaryZ = -10f + transform.localScale.z * 0.5f;
        float upperBoundaryX = 460.5f - transform.localScale.x * 0.5f; //set player position back by 0.5 when colliding with upper boundary
        float upperBoundaryZ = 10f - transform.localScale.z * 0.5f;


        if(x <= lowerBoundaryX || x > upperBoundaryX) //set character velocity to go in reverse when in collision with boundaries on x axis
        {
            characterVelocityX = -characterVelocityX;
        }

        if(z <= lowerBoundaryZ || z > upperBoundaryZ) //set character velocity to go in reverse when in collision with boundaries on z axis
        {
            characterVelocityZ = -characterVelocityZ;
        }

        x = Mathf.Clamp(x, lowerBoundaryX, upperBoundaryX); //set MIN and MAX boundary values for x

        z = Mathf.Clamp(z, lowerBoundaryZ, upperBoundaryZ); //set MIN and MAX bounadry values for z

        transform.position = new Vector3(x, y, z); //set new position


    }

}
