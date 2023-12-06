using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Editable Variables")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpStrength = 8f, upGravity = 1f, downGravity = 5f, jumpAddition = 0.5f;

    [Header("Assignable Variables")]
    //Layer on which the character can collide with and walk on
    [SerializeField] private LayerMask groundLayers;
    //Empty game object that need to be placed at the bottom of the character sprite
    [SerializeField] private Transform groundCheck;
    //[SerializeField] private Checkpoint checkpoint;

    //Variable only used while the script is running
    private float horizontal;
    private bool jump, longJump;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    //private Animator animator;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        //"Horizontal" is already assigned to the right key, when pressed they give a value between -1 and 1 (-1 is going toward left and 1 toward right)
        horizontal = Input.GetAxisRaw("Horizontal"); 

        //Verify if the player is using the input jump (assignated to Space) and is on the ground
        if (Input.GetButtonDown("Jump") && GroundCheck())
        { 
            jump = true;  
        }

        //else if (Input.GetButton("Jump") && GroundCheck())
        //{
        //   longJump = true;
        //}

        //Change the Sprite Renderer flip according to the horizontal float, if positive the character is facing right, else they are facing left
        FlipSprite();

        //Change the animation depending on the state the player is
        Animation(GroundCheck());
        
    }

    private void FixedUpdate()
    {
        //Using the value from "Horizontal" we move the player +speed or -speed in the X axis
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y);

        //If jump is true the player can jump, when their upward movement is done the gravity increase to make them fall faster
        if (jump)
        {
            rb.gravityScale = upGravity;
            rb.AddForce (new Vector3(rb.velocity.x, jumpStrength), ForceMode2D.Impulse);
            jump = false;
        }
        //else if(longJump)
        //{
        //    rb.gravityScale = upGravity;
        //    rb.AddForce(new Vector3(rb.velocity.x, jumpStrength + jumpAddition), ForceMode2D.Impulse);
        //    longJump = false;
        //}
        if (!GroundCheck() && rb.velocity.y < 0)
        {
            rb.gravityScale = downGravity;
        }
    }

    //Boolean returning true if the player touches the Ground layer or false if the player is not touching the layer ground
    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundLayers);
    }

    private void FlipSprite()
    {
        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void Animation(bool GroundCheck)
    {
        if (horizontal != 0 && GroundCheck)
        {
            //animator.SetBool("toWalk", true);
            //animator.SetBool("toJump", false);
            //animator.SetBool("toFall", false);
        }
        else if (!GroundCheck && rb.velocity.y > 0)
        {
            //animator.SetBool("toJump", true);
        }
        else if (!GroundCheck && rb.velocity.y <= 0)
        {
            //animator.SetBool("toJump", false);
            //animator.SetBool("toFall", true);
        }
        else
        {
            //animator.SetBool("toWalk", false);
            //animator.SetBool("toJump", false);
            //animator.SetBool("toFall", false);
        }
    }
}
