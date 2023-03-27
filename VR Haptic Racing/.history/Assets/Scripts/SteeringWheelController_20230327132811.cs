using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class SteeringWheelController : MonoBehaviour
{
    public float steeringWheelInput;
    public float acceleratorInput;
    public float brakeInput;

    private PlayerIndex playerIndex;
    private GamePadState state;
    private GamePadState prevState;
    private Rigidbody rb;

    public float speed = 1.0f;
    public float rotationSpeed = 23.0f;
    public float deceleration = 3.0f; // Deceleration factor when not pressing triggers


    void Start()
    {
        playerIndex = PlayerIndex.One;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);
        steeringWheelInput = state.ThumbSticks.Left.X;
        acceleratorInput = state.Triggers.Right;
        brakeInput = state.Triggers.Left;

    }

    void FixedUpdate() 
    {

        float moveVertical = acceleratorInput  - brakeInput; // Use pedals for acceleration/deacceleration (& reverse) movement

        float rotation = steeringWheelInput * rotationSpeed * Time.deltaTime;
        Quaternion turn = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * turn);

        Vector3 movement = transform.forward * moveVertical;

        if (moveVertical == 0f) 
        {

            // Apply deceleration if not pressing triggers
            rb.velocity -= rb.velocity * deceleration * Time.deltaTime;
        }

        rb.AddForce(movement * speed);
    }
}
