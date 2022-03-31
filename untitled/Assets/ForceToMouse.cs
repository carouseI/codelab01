using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceToMouse : MonoBehaviour
{
    private Rigidbody2D rb2DCoin;

    public Transform mouseDiamond;
    // Start is called before the first frame update
    void Start()
    {
        rb2DCoin = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2DCoin.AddForce(transform.position - mouseDiamond.position * 0.1f, ForceMode2D.Force);
    }
}
