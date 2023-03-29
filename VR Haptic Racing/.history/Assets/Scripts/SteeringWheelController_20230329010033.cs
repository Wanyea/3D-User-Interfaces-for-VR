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
    private Vector3 steeringWheelForward;
    private Vector3 eulerRotation;

    public float speed = 5.0f;
    public float rotationSpeed = 70.0f;
    public float deceleration = 1.0f; // Deceleration factor when not pressing triggers
    //public float steeringWheelRotationMultiplier = 140.0f;

    public float moveSpeed = 10f;
    public float turnSpeed = 100f;
    public float maxTurnAngle = 30f;
    public float steeringWheelRotationMultiplier = 1f;
    public float stopThreshold = 0.1f;

    void Start()
    {
        playerIndex = PlayerIndex.One;
        rb = GetComponent<Rigidbody>();
        steeringWheelForward = steeringWheelObject.transform.forward;
        eulerRotation = steeringWheelObject.transform.rotation.eulerAngles;

    }

    void Update()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);
        steeringWheelInput = state.ThumbSticks.Left.X;
        acceleratorInput = state.Triggers.Right;
        brakeInput = state.Triggers.Left;

        // Rotate steering wheel game object by similar rotation of 
        // the phsyical steering wheel input device  
        if (steeringWheelObject != null) 
        {
            float rotationAngle = -steeringWheelInput * steeringWheelRotationMultiplier;
            Quaternion rotation = Quaternion.AngleAxis(rotationAngle, steeringWheelForward);
            steeringWheelObject.transform.rotation = transform.rotation * rotation;
        }

    }

    void FixedUpdate() 
    {

        float moveVertical = acceleratorInput  - brakeInput; // Use pedals for acceleration/deacceleration (& reverse) movement

        Vector3 movement = transform.forward * moveVertical;

        if (moveVertical == 0f) 
        {

            // Apply deceleration if not pressing pedals (Can change this value depending on what user is driving on to simulate friction)
            rb.velocity -= rb.velocity * deceleration * Time.deltaTime;
            
        } else { 
            Quaternion desiredRotation = Quaternion.Euler(0f, rotationAngle, 0f);
            // steeringWheelObject.transform.rotation = transform.rotation * Quaternion.Euler(0f, 0f, rotationAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, turnSpeed * Time.deltaTime);
        
        }

        rb.AddForce(movement * speed);
    }
}
