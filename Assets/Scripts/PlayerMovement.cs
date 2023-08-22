using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator anim;
    public AudioSource audioSource;
    public AudioClip mlem;
  
    [SerializeField] float cayoteTime = 0.2f;
    [SerializeField] float cayoteTimeCounter;
    [SerializeField] float apexTimer;
    [SerializeField] float apexCounter;
    [SerializeField] float fallSpeed = 5f;
    private float horizontal;
    [SerializeField] float speed = 10f;
    [SerializeField] float speedBonus = 2f;
    [SerializeField] float jumpPower = 10f;
    private bool isFacingRight = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isGrounded", isGrounded());
        
        if (isGrounded())
        {
            cayoteTimeCounter = cayoteTime;
        }
        else
        {
            cayoteTimeCounter -= Time.deltaTime;
        }

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
        apexTimer -= Time.deltaTime;
        HorizontalSpeed();
        
        WhenInAir();

        
    }

    public void Jump(InputAction.CallbackContext context )
    {

        
        if (context.performed  && cayoteTimeCounter > 0f)
        {
            audioSource.PlayOneShot(mlem);
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            

        }

        if ( context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            cayoteTimeCounter = 0;
        }
    }

   

    private void WhenInAir()
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
            rb.gravityScale = 4;
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


    private void HorizontalSpeed()
    {
       
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        anim.SetFloat("Speed", rb.velocity.x);
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
