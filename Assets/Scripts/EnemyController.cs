using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool movingRight;

    private Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;
    private Animator animator;

    public float moveTime, waitTime;
    private float moveCount, waitCount;

    private float MIN_VALUE_WAIT = .75f;
    private float MAX_VALUE_WAIT = .45f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        leftPoint.parent = null; 
        rightPoint.parent = null;

        movingRight = true;

        moveCount = moveTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;
            if (movingRight)
            {
                rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
                spriteRenderer.flipX = true;

                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
                spriteRenderer.flipX = false;

                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }

            if (moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * MIN_VALUE_WAIT, waitTime * MAX_VALUE_WAIT);
            }
            animator.SetBool("isMoving", true);
        }
        else if (waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            if (waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * MIN_VALUE_WAIT, moveTime * MAX_VALUE_WAIT);
            }
            animator.SetBool("isMoving", false);
        }

    }
}
