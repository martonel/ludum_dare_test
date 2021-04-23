using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private float moveInput;
    public float Speed = 20.0f;
    public float JumpForce;   //10
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float chechRadius;
    public LayerMask whatIsGround;
    private bool facingRight = true;
    private int extraJump;
    public int extraJumpValue = 2;









    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        extraJump = extraJumpValue;
        //transform.position = startPos.initialVector;
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, chechRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);
        if (moveInput == 0)
        {
           // anim.SetBool("isRunning", false);
        }
        if (moveInput > 0)
        {
            //anim.SetBool("isRunning", true);
            if (facingRight == false)
            {
                Flip();
            }
        }
        else if (moveInput < 0)
        {
            //anim.SetBool("isRunning", true);
            if (facingRight == true)
            {
                Flip();
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                extraJump = extraJumpValue;
            }
            if (extraJump != 0)
            {
                //anim.SetTrigger("Jump");
                rb.velocity = Vector2.up * JumpForce;
                extraJump--;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = Vector2.down * 5.0f;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


}
