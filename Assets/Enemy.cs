using UnityEngine;

public class Enemy : Entity
{
    private bool playerDetected;

    protected override void Update()
    {
        HandleCollision();
        HandleAnimations();
        HandleMovment(facingDir);
        HandleFlip();
        HandleAttack();
    }

    protected override void HandleAttack()
    {
        if (playerDetected)
            anim.SetTrigger("attack");
    }

    protected override void HandleCollision()
    {
        base.HandleCollision();
        playerDetected = Physics2D.OverlapCircle(attackPoint.position, attackRadius, whatIsTarget);
    }

}
