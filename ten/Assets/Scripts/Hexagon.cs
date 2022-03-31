using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{

    public Rigidbody2D rb; //reference to rigidbody

    public float shrinkSpeed = 3f; //defining shrink speed


    // Start is called before the first frame update
    void Start()
    {
        rb.rotation = Random.Range(0f, 360f); //set random rotation for rigidbody
        transform.localScale = Vector3.one * 10f; //set scale
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime; //shrink

        if(transform.localScale.x <= .05f)
        {
            Destroy(gameObject);
        }
    }
}
