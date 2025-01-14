using UnityEngine;

public class BoatControllerWithoutRigidbody : MonoBehaviour
{
    [Header("Movement Settings")]
    public float maxSpeed = 20f;           // Maximum forward speed
    public float acceleration = 10f;       // Acceleration rate
    public float deceleration = 5f;        // Deceleration rate
    public float reverseSpeed = 10f;       // Maximum reverse speed
    public float turnSpeed = 50f;          // Turning speed

    private float mass = 0.5f;

    private float currentSpeed = 0f;       // Current speed of the boat

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        // Get input for acceleration and turning
        float moveInput = Input.GetAxis("Vertical");   // W/S or Up/Down
        float turnInput = Input.GetAxis("Horizontal"); // A/D or Left/Right

        // Accelerate or decelerate the boat
        if (moveInput > 0) // Forward
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (moveInput < 0) // Reverse
        {
            currentSpeed -= acceleration * Time.deltaTime;
        }
        else // No input, apply deceleration
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
        }

        // Clamp speed to maximum forward and reverse speeds
        currentSpeed = Mathf.Clamp(currentSpeed, -reverseSpeed, maxSpeed);

        // Move the boat forward
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        // Turn the boat (only if moving to avoid spinning in place)
        if (Mathf.Abs(currentSpeed) > 0.1f)
        {
            float turnAmount = turnInput * turnSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up * turnAmount);
        }
    }
}
