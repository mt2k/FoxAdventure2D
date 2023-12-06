using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed;
    public Rigidbody2D rg2D;
    public float jumpForce;
    private bool isGrounded;

    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rg2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knockBackCounter <= 0)
        {
            /* Stop Unlimited Jumping with Space 
             */
            rg2D.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rg2D.velocity.y);
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

            /* Adding Double Jump
             */

            if (isGrounded)
            {
                canDoubleJump = true;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    rg2D.velocity = new Vector2(rg2D.velocity.x, jumpForce);
                }
                else
                {
                    if (canDoubleJump)
                    {
                        rg2D.velocity = new Vector2(rg2D.velocity.x, jumpForce);
                        canDoubleJump = false;
                    }
                }
            }

            if (rg2D.velocity.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (rg2D.velocity.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
            if (!spriteRenderer.flipX)
            {
                rg2D.velocity = new Vector2(-knockBackForce, rg2D.velocity.y);
            }
            else
            {
                rg2D.velocity = new Vector2(knockBackForce, rg2D.velocity.y);
            }
        }

        animator.SetFloat("moveSpeed", Mathf.Abs(rg2D.velocity.x));
        animator.SetBool("isGrounded", isGrounded);
    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        rg2D.velocity = new Vector2(0f, knockBackForce);

        animator.SetTrigger("hurt");
    }
}
