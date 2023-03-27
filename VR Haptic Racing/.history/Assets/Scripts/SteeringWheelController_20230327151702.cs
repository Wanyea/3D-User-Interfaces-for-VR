using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class SteeringWheelController : MonoBehaviour
{
    public float steeringWheelInput;
    public float acceleratorInput;
    public float brakeInput;
    public GameObject steeringWheelObject;

    private PlayerIndex playerIndex;
    private GamePadState state;
    private GamePadState prevState;
    private Rigidbody rb;

    public float speed = 5.0f;
    public float rotationSpeed = 23.0f;
    public float deceleration = 1.0f; // Deceleration factor when not pressing triggers
    public float steeringWheelRotationMultiplier = 360f;


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

        if (steeringWheel)

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

            // Apply deceleration if not pressing pedals (Can change this value depending on what user is driving on to simulate friction)
            rb.velocity -= rb.velocity * deceleration * Time.deltaTime;
        }

        rb.AddForce(movement * speed);
    }
}
