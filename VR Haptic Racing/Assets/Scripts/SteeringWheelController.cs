using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class SteeringWheelController : MonoBehaviour
{
    public float steeringWheelInput;
    private PlayerIndex playerIndex;
    private GamePadState state;
    private GamePadState prevState;
    private Rigidbody rb;

    public float speed = 1.0f;
    public float rotationSpeed = 23.0f;
    public float deceleration = 3.0f; // Deceleration factor when not pressing triggers


    // Start is called before the first frame update
    void Start()
    {
        playerIndex = PlayerIndex.One;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);
        steeringWheelInput = state.ThumbSticks.Left.X;

    }

    void FixedUpdate() 
    {

        float moveVertical = state.Triggers.Right - state.Triggers.Left; // Use triggers for forward/backward movement

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
