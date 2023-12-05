using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.Space;

    private CharacterController characterController;
    private bool canDoubleJump = true;
    private bool isGrounded;

    private Vector3 velocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = characterController.isGrounded;

        Move();
        Jump();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f);
        Vector3 moveVelocity = moveDirection * moveSpeed;

        characterController.Move(moveVelocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            canDoubleJump = true;
            velocity.y = -0.5f; // Reset velocity when grounded to prevent accumulating gravity
        }

        if (Input.GetKeyDown(jumpKey))
        {
            if (isGrounded || canDoubleJump)
            {
                velocity.y = Mathf.Sqrt(2f * jumpForce * Mathf.Abs(Physics.gravity.y));
                canDoubleJump = !isGrounded;
            }
        }

        // Apply gravity
        velocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}