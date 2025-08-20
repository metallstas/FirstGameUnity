using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    protected Animator anim;
    protected Rigidbody2D rb;

    [Header("Attack Details")]
    [SerializeField] protected float attackRadius;
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected LayerMask whatIsTarget;
    
    [Header("MovmentDetails")]
    [SerializeField] protected float moveSpeed = 8.0f;
    [SerializeField] private float jumpForce = 13.0f;
    protected int facingDir = 1;
    private float xInput;
    private bool isFacingRight = true;
    protected bool canMove = true;
    private bool canJump = true;


    [Header("CollisionDetails")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    protected bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
    protected virtual void Update()
    {
        HandleCollision();
        HandleInput();
        HandleMovment(xInput);
        HandleAnimations();
        HandleFlip();
       
    }

    public void DamageTargets()
    {
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, whatIsTarget);
        foreach (Collider2D entity in enemyColliders)
        {
            //entity.GetComponent<Entity>().TakeDamage();
        }
    }

    private void TakeDamage()
    {
        throw new NotImplementedException();
    }

    public void EnableMovmentAndJump(bool enable)
    {
        canJump = enable;
        canMove = enable;
    }

    protected void HandleAnimations()
    {
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    private void HandleInput()
    {
        xInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryToJump();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            HandleAttack();
        }
      
    }

    protected virtual void HandleAttack()
    {
        if (isGrounded)
            anim.SetTrigger("attack");
    }

    private void TryToJump()
    {
        if (isGrounded && canJump)
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
    }

    protected virtual void HandleCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    protected virtual void HandleMovment(float xDirection)
    {
        if (canMove)
            rb.linearVelocity = new Vector2(xDirection * moveSpeed, rb.linearVelocity.y);
        else
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

    }

    protected void HandleFlip()
    {
        if (rb.linearVelocityX > 0 && isFacingRight == false)
            Flip();
        else if (rb.linearVelocityX < 0 && isFacingRight == true)
            Flip();
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
        facingDir *= -1;
    }

    protected void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance));
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
