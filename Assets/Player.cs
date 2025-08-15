using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float jumpForce = 15.0f;
    private float xInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        handleInput();
        handleMovment();   
       
    }

    private void handleInput()
    {
        xInput = Input.GetAxis("Horizontal");


        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
    }

    private void handleMovment()
    {
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
    }
}
