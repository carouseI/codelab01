using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = Mathf.Sin(Time.time); //set y to Sine wave; move through time, ping pong between 1 and -1
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z); //constantly set position to Vector3.0
    }
}
