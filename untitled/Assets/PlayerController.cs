using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool is3D;

    private Rigidbody rb;
    private Rigidbody2D rb2D;

    private HingeJoint hj;
    private HingeJoint2D hj2D;

    private JointMotor motor;
    private JointMotor2D motor2D;

    // Start is called before the first frame update
    void Start()
    {
        if (is3D){
            rb = gameObject.GetComponent<Rigidbody>();
            hj = gameObject.GetComponent<HingeJoint>();
        } else {
            rb2D = gameObject.GetComponent<Rigidbody2D>();
            hj2D = gameObject.GetComponent<HingeJoint2D>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (is3D){
            motor = hj.motor;

        }else {
            motor2D = hj2D.motor;

            if (Input.GetKey(KeyCode.Space)){
                motor2D.motorSpeed += 50f;
                rb2D.AddForce(Vector2.up, ForceMode2D.Impulse);
            } else {
                motor2D.motorSpeed -= 50f;
            }

            hj2D.motor = motor2D;
        }
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Collectible")){
            Debug.Log("It's a collectible!");
        }
    }
}
