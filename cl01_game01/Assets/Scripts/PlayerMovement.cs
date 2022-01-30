using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 7f; //serialise = expose to editor, change directly in unity
    [SerializeField]private float jumpForce = 14f; //public = not as good, allows access to all scripts

    private enum MovementState { idle, running, jump, fall } //create own data type, finite set of values
    //private MovementState state = MovementState.idle;

    //int wholeNumber = 16; //store whole number in variable
    //float decimalNumber = 4.56f; //floating point literal
    //string text = "blank"; //entry text
    //bool boolean = false; //check true/false conditions, executes based on condition

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log("Hello, world!");

        dirX = Input.GetAxisRaw("Horizontal"); //left: -1, right: +1
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && IsGrounded()) //GBD vs GKD, uses input system
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); //call rigidbody + add speed
        }

        UpdateAnimationState(); //call method
    }

    private void UpdateAnimationState() //no results returned, exclusive execution
    {

        MovementState state; //local variable, values assigned below

        if (dirX > 0f)
        {
            //anim.SetBool("running", true);
            state = MovementState.running;
            sprite.flipX = false; //flip sprite, match to right movement

        }
        else if (dirX < 0)
        {
            //anim.SetBool("running", true); //running to the left
            state = MovementState.running;
            sprite.flipX = true; //flip sprite, match to left movement
        }
        else
        {
            //anim.SetBool("running", false); //set to idle
            state = MovementState.idle;
        }

        if(rb.velocity.y > .1f) //player is in air, execute jumping animation
        {
            state = MovementState.jump;
        }
        else if(rb.velocity.y < -1f) //execute falling animation
        {
            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state); //(int) = turn enum into corresponding integer rep
    }

    private bool IsGrounded() //check if player is grounded
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround); //create box around player, offset downwards, check for overlap with jumpableGround
    }
}
