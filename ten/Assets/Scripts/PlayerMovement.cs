using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 600f; //how fast

    float movement = 0f; //variable to store input

    // Update is called once per frame
    void Update()
    {
       movement = Input.GetAxisRaw("Horizontal"); //a+d, left+right
    }

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed); //rotate around certain point; (-) for reverse
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //restart level when something enters trigger
    }
}
