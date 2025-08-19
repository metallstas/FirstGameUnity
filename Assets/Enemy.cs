using UnityEngine;

public class Enemy : Entity
{

    protected override void Update()
    {
        HandleCollision();
        HandleAnimations();
        HandleMovment(facingDir);
        HandleFlip();
    }

}
