using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    [SerializeField]
    private int _amplitude = 1; //multiply Sine function by amplitude value

    [SerializeField]
    private float _frequency = 0.1f; //adjust how quick movement is

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region //Sin
        //float x = transform.position.x;
        float y = Mathf.Sin(Time.time * _frequency) * _amplitude; //set y to Sine wave; move through time, ping pong between 1 and -1
        //float z = transform.position.z;

        //transform.position = new Vector3(x, y, z); //constantly set position to Vector3.0
        #endregion

        #region //Cos
        float x = Mathf.Cos(Time.time *  _frequency) * _amplitude; //multiply to adjust height/length of cosine
        //float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z); //set pos to Vector 3 @ 0
        #endregion

        //sin + cos = perfect circles
    }
}
