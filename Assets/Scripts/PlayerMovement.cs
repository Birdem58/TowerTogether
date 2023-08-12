using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    [SerializeField] float apexTimer;
    [SerializeField] float apexCounter;
    [SerializeField] float fallSpeed = 5f;
    private float horizontal;
    [SerializeField] float speed = 10f;
    [SerializeField] float speedBonus = 2f;
    [SerializeField] float jumpPower = 10f;
    private bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        apexTimer -= Time.deltaTime;
        WhenInAir();


        if ( !isFacingRight && horizontal > 0f)
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

    public void WhenInAir()
    {
        
        

       
        if (rb.velocity.y <= 1 && rb.velocity.y >= -1 && !isGrounded() )
        {
            rb.velocity = new Vector2(horizontal * speed * speedBonus, rb.velocity.y);
            
        }
        else if (rb.velocity.y < -fallSpeed && !isGrounded())
        {
            rb.velocity = new Vector2(horizontal * speed, -fallSpeed + 1);
        }
        if(apexTimer <= 0) 
        {
            rb.gravityScale = 3;
        }
        else if(apexTimer > 0)
        {
            rb.gravityScale = 2;
        }
        if(isGrounded())
        {
            apexTimer = apexCounter;
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



    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
