using UnityEngine;

public class BoatControllerWithoutRigidbody : MonoBehaviour
{
    [Header("Movement Settings")]
    public ObservableFloat maxSpeed;           // Maximum forward speed
    public float acceleration = 10f;       // Acceleration rate
    public float deceleration = 5f;        // Deceleration rate
    public float reverseSpeed = 10f;       // Maximum reverse speed
    public float turnSpeed = 50f;          // Turning speed

    public ObservableFloat currentSpeed;       // Current speed of the boat

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
            currentSpeed.Value += acceleration * Time.deltaTime;
        }
        else if (moveInput < 0) // Reverse
        {
            currentSpeed.Value -= acceleration * Time.deltaTime;
        }
        else // No input, apply deceleration
        {
            currentSpeed.Value = Mathf.MoveTowards(currentSpeed.Value, 0f, deceleration * Time.deltaTime);
        }

        // Clamp speed to maximum forward and reverse speeds
        currentSpeed.Value = Mathf.Clamp(currentSpeed.Value, -reverseSpeed, maxSpeed.Value);

        // Move the boat forward
        transform.Translate(Vector3.forward * currentSpeed.Value * Time.deltaTime);

        // Turn the boat (only if moving to avoid spinning in place)
        if (Mathf.Abs(currentSpeed.Value) > 0.1f)
        {
            float turnAmount = turnInput * turnSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up * turnAmount);
        }
    }
}
