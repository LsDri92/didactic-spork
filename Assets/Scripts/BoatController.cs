using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using Unity.VisualScripting;

public class WaterBoat : MonoBehaviour
{

    public Transform Motor;
    public float SteerPower = 500f;
    public float timeZeroToMax = 2.5f;
    public float timeMaxToZero = 6f;
    public float timeBrakeToZero = 1f;
    public float MaxSpeed = 6f;
    float accelRatePerSec;
    float decelRatePerSec;
    float brakeRatePerSec;
    float forwardVelocity;

    protected Rigidbody Rigidbody;
    protected Quaternion StartRotation;
    protected ParticleSystem ParticleSystem;
    private PlayerInput playerInput;
    private Vector2 input;

    public void Awake()
    {
        accelRatePerSec = MaxSpeed / timeZeroToMax;
        decelRatePerSec = -MaxSpeed / timeMaxToZero;
        brakeRatePerSec = -MaxSpeed / timeBrakeToZero;

        forwardVelocity = 0;

        Rigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        StartRotation = Motor.localRotation;
        ParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        input = playerInput.actions["move"].ReadValue<Vector2>();
        print(input);
    }

    void FixedUpdate()
    {
        if (input.y > 0)
        {
            Accelerate(accelRatePerSec);

        }
        else if (input.y == 0)
        {
            Accelerate(decelRatePerSec);
        }
        else if (input.y < 0)
        {
            Decelerate(accelRatePerSec);

        }

        Rigidbody.linearVelocity = transform.forward * forwardVelocity;

        var steer = -input.x;
        Rigidbody.AddForceAtPosition(steer * transform.right * SteerPower / 100f, Motor.position);
    }
    //  TODO "GEARSSTATE"
    void Accelerate(float accel)
    {
        forwardVelocity += accel * Time.deltaTime;
        forwardVelocity = Mathf.Clamp(forwardVelocity, -MaxSpeed, MaxSpeed);
    }

    void Decelerate(float accel)
    {
        forwardVelocity -= accel * Time.deltaTime;
        forwardVelocity = Mathf.Clamp(forwardVelocity, -MaxSpeed, MaxSpeed);
    }

}
