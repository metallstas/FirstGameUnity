using UnityEngine;

public class Player : Entity
{
    private float xInput;
    private bool canJump = true;

    [Header("MovmentDetails")]
    [SerializeField] private float jumpForce = 13.0f;


    protected override void Update()
    {
        base.Update();
        HandleInput();
        HandleMovment(xInput);
    }

    private void HandleInput()
    {
        xInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
            TryToJump();

        if (Input.GetKeyDown(KeyCode.J))
            HandleAttack();

    }

    public override void EnableMovment(bool enable)
    {
        base.EnableMovment(enable);
        canJump = enable;
    }
    private void TryToJump()
    {
        if (isGrounded && canJump)
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
    }

}
