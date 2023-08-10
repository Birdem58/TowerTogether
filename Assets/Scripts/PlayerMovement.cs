using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float downForce = 5f;
    private float horizontal;
    private float speed = 10f;
    private float jumpPower = 10f;
    private bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if( !isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if(isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    public void Jump(InputAction.CallbackContext context )
    {
        if(context.performed && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        if ( context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    
    }

    public void FreeFall()
    {

    }
    public void Fall(InputAction.CallbackContext context)
    {
       if(isGrounded() == false && context.performed)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, - downForce);
        }
       if(isGrounded() && context.canceled)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0f);
        }
    }


    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
