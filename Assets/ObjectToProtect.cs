using UnityEngine;

public class ObjectToProtect : Entity
{

    [SerializeField] private Transform player;

    protected override void Update()
    {
        HandleFlip();
    }

    protected override void HandleFlip()
    {
        if (player.transform.position.x > transform.position.x && isFacingRight == false)
            Flip();
        else if (player.transform.position.x < transform.position.x && isFacingRight == true)
            Flip();
    }

    protected override void Die()
    {
        base.Die();
        UI.instace.EnableGameOver();
    }
}
