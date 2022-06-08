using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 2.5f;
    public float doubleJumpSpeed = 2f;

    private bool canDoubleJump;

    public bool betterJump = true;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    public SpriteRenderer spriteRenderer;
    public Animator RunAnimator;

    public GameObject dustLeft;
    public GameObject dustRight;

    Rigidbody2D rb2D;

    public float dashCoolDown;
    public float dashForce;
    public GameObject dashParticle;

    bool isTouchingFront = false;
    bool wallSliding;

    public float wallSlidingSpeed = 0.75f;

    bool isTouchingDerecha;
    bool isTouchingIzquierda;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        dashCoolDown -= Time.deltaTime;

        if ((Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && wallSliding == false)
        {
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true;
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            }else if ((Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && wallSliding == false)
            {
                if (canDoubleJump && wallSliding == false)
                {
                    RunAnimator.SetBool("DoubleJump", true);
                    rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                    canDoubleJump = false;
                }
            }
        }

        if (CheckGround.isGrounded == false)
        {
            RunAnimator.SetBool("Jump", true);
            RunAnimator.SetBool("Run", false);
        }
        else if (CheckGround.isGrounded == true)
        {
            RunAnimator.SetBool("Jump", false);
            RunAnimator.SetBool("DoubleJump", false);
            RunAnimator.SetBool("Falling", false);

        }

        if(rb2D.velocity.y> 0)
        {
            RunAnimator.SetBool("Falling", false);
        }

        if (betterJump)
        {
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
                RunAnimator.SetBool("Falling", true);
            }
            else if ((rb2D.velocity.y > 0 && !Input.GetKey("space")) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.W))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }


        if (isTouchingFront == true && CheckGround.isGrounded == false && Input.GetKey(KeyCode.LeftShift))
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            RunAnimator.Play("Wall");
            rb2D.velocity = new Vector2(rb2D.velocity.x, Mathf.Clamp(rb2D.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
    }

    void FixedUpdate()
    {
        if ((Input.GetKey("d") || Input.GetKey("right")) && isTouchingDerecha == false)
        {

            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            RunAnimator.SetBool("Run", true);

            if (CheckGround.isGrounded == true)
            {
                dustLeft.SetActive(true);
                dustRight.SetActive(false);
            }
            if (Input.GetKey("e") && dashCoolDown <= 0 || Input.GetKey("right ctrl") && dashCoolDown <= 0)
            {
                Dash();
            }

        }
        else if (Input.GetKey("e") && dashCoolDown<=0 || Input.GetKey("right ctrl") && dashCoolDown <= 0)
        {
            Dash();
        }
        else if ((Input.GetKey("a") || Input.GetKey("left")) && isTouchingIzquierda == false)
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            RunAnimator.SetBool("Run", true);

            if (CheckGround.isGrounded == true)
            {
                dustLeft.SetActive(false);
                dustRight.SetActive(true);
            }
            if (Input.GetKey("e") && dashCoolDown <= 0 || Input.GetKey("right ctrl") && dashCoolDown <= 0)
            {
                Dash();
            }
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            RunAnimator.SetBool("Run", false);
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
        }
        
    }

    public void Dash()
    {
        GameObject dashObject;
        dashObject = Instantiate(dashParticle, transform.position, transform.rotation);
        if (spriteRenderer.flipX == true)
        {
            rb2D.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
        }
        else
        {
            rb2D.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
        }

        dashCoolDown = 2;

        Destroy(dashObject, 1);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ParedDerecha"))
        {
            isTouchingFront = true;
            isTouchingDerecha = true; 
        }

        if (collision.gameObject.CompareTag("ParedIzquierda"))
        {
            isTouchingFront = true;
            isTouchingIzquierda = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouchingFront = false;
        isTouchingDerecha = false;
        isTouchingIzquierda = false;
    }
}