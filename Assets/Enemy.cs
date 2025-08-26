using UnityEngine;

public class Enemy : Entity
{
    private bool playerDetected;
    private Transform player;

    protected override void Awake()
    {
        base.Awake();
        player = FindFirstObjectByType<Player>().transform;
    }

    protected override void Update()
    {
        base.Update();
        HandleMovment(facingDir);
        HandleAttack();
    }

    protected override void HandleFlip()
    {
        if (player != null)
            return;

        base.HandleFlip();
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

    protected override void Die()
    {
        base.Die();
        UI.instace.AddKillCount();
    }

}
