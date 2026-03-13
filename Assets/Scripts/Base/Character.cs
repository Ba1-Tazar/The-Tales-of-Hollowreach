using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterController controller; 
    private Vector3 velocity;

    [Header("Movement Settings")]
    public float moveSpeed = 5.0f;
    public float sprintSpeed = 8.0f;
    public float crouchSpeed = 2.5f;

    [Header("Physics Settings")]
    public float jumpHeight = 3.0f;
    public float gravity = -30f; 

    [Header("Crouch Settings")]
    public float standHeight = 2.0f;
    public float crouchHeight = 1.0f;

    public void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Move(Vector3 direction, bool isSprinting)
    {
        // Decide which speed to use
        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;

        // Reset gravity if we are touching the ground to prevent build up
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Calculate gravity
        velocity.y += gravity * Time.deltaTime;

        // Bundle horizontal movement and vertical gravity into one Vector3
        Vector3 finalMove = (direction * currentSpeed) + velocity;

        // Execute movement
        controller.Move(finalMove * Time.deltaTime);
    }

    public void Jump()
    {
        // Only jump if we are touching the ground
        if (controller.isGrounded)
        {
            // Physics formula: Velocity = Square Root of (Height * -2 * Gravity)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * -9.81f);
        }
    }
}

