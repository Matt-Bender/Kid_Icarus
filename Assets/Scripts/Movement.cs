using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{

    public int JumpForce;
    public float speed;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    //private bool isFacingLeft = false;
    public SpriteRenderer marioSprite;

    Animator anim;
    Rigidbody2D myRigidBody;


    private int counter = 0;
    //increases by 5 for every feather picked up
    public int featherCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (speed <= 0)
        {
            speed = 5.0f;
        }
        if (JumpForce <= 0)
        {
            JumpForce = 5;
        }
        if (!groundCheck)
        {
            Debug.Log("Groundcheck is not found. Please assign an object to be the groundcheck");
        }
        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //GetAxisRaw no smoothing - instantly goes from 0 to 1 or -1
        //GetAxis smoothing
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        myRigidBody.velocity = new Vector2(horizontalInput * speed, myRigidBody.velocity.y);
        anim.SetFloat("horizontalInput", Mathf.Abs(horizontalInput));
        //anim.SetBool("Jump", !isGrounded);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //counter to check if jump has been increased
            //if so after 5 jumps jump height goes down to normal
            //then resets counter
            if (JumpForce > 200)
            {
                Debug.Log("Super Jump");
                counter++;
                if(counter >= 5)
                {
                    JumpForce /= 2;
                }
            }
            else
            {
                counter = 0;
            }
            myRigidBody.velocity = Vector2.zero;

            myRigidBody.AddForce(Vector2.up * JumpForce);
        }
        Crouching();
        lookingUp();
        //bool attack = Input.GetButtonDown("Fire1");
        ////press control
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    anim.SetBool("Attack", true);
        //    Debug.Log("Fire1 is pressed");
        //}
        //hold space and press control
        //if ((Input.GetButton("Jump")) && Input.GetButtonDown("Fire1"))
        //{
        //    Debug.Log("Jump attack is pressed");
        //    anim.SetBool("JumpAttack", true);
        //}



        //if (horizontalInput > 0 && isFacingLeft)
        //{
        //    flip();
        //}
        //else if (horizontalInput < 0 && !isFacingLeft)
        //{
        //    flip();
        //}

        //if (horizontalInput > 0 && marioSprite.flipX == true || horizontalInput < 0 && marioSprite.flipX == false)
        //{
        //    marioSprite.flipX = !marioSprite.flipX;
        //    //flip();
        //}

        if (horizontalInput > 0 && marioSprite.flipX == true)
        {
            marioSprite.flipX = !marioSprite.flipX;
        }
        if (horizontalInput < 0 && marioSprite.flipX == false)
        {
            marioSprite.flipX = !marioSprite.flipX;
        }
    }
    public void Crouching()
    {
        if (Input.GetKeyDown("w"))
        {
            anim.SetBool("isLookingUp", true);
        }
        if (Input.GetKeyUp("w"))
        {
            anim.SetBool("isLookingUp", false);
        }
    }
    public void lookingUp()
    {
        if (Input.GetKeyDown("s"))
        {
            anim.SetBool("isCrouching", true);
        }
        if (Input.GetKeyUp("s"))
        {
            anim.SetBool("isCrouching", false);
        }
    }
    //functions to stop attack animations
    public void setAttack()
    {
        anim.SetBool("Attack", false);
    }
    public void setJumpAttack()
    {
        anim.SetBool("JumpAttack", false);
    }

    void flipRight()
    {
        //isFacingLeft = !isFacingLeft;
        //marioSprite.flipX = isFacingLeft;
        //setting vector 3 to local scale
        //Vector3 scaleFactor = transform.localScale;
        //scaleFactor.x = -scaleFactor.x;
        //transform.localScale = scaleFactor;
    }
    void flipLeft()
    {

    }
}
