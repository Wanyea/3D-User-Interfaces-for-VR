using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

[System.Serializable]
public class AxleInfo 
{
    public WheelCollider leftWheelCollider;
    public WheelCollider rightWheelCollider;
    public bool motor;
    public bool steering;
}

public class SteeringWheelController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; 
    public Vector3 centerOfMassOffset = new Vector3(0, -0.5f, 0);
    public float maxMotorTorque = 2000.0f;
    public float maxSteeringAngle = 50.0f;
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
    public float speed = 100.0f;
    public float rotationSpeed = 70.0f;
    public float steeringWheelRotationMultiplier = 140.0f;
    public float wheelsRotationMultiplier = 70.0f;
    public float wheelsRotationAngle;
    public float maxSidewaysFriction = 2.0f;
    public float maxForwardFriction = 1.5f;

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0) 
        {
            return;
        }
     
        Transform visualWheel = collider.transform.GetChild(0);
     
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
     
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    void Start()
    {
        playerIndex = PlayerIndex.One;
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass += centerOfMassOffset;
        steeringWheelForward = steeringWheelObject.transform.forward;
        eulerRotation = steeringWheelObject.transform.rotation.eulerAngles;

        // Set up wheel collider properties for better handling
        foreach (AxleInfo axleInfo in axleInfos) 
        {
            WheelFrictionCurve sidewaysFriction = axleInfo.leftWheelCollider.sidewaysFriction;
            sidewaysFriction.stiffness = maxSidewaysFriction;
            axleInfo.leftWheelCollider.sidewaysFriction = sidewaysFriction;
            axleInfo.rightWheelCollider.sidewaysFriction = sidewaysFriction;

            WheelFrictionCurve forwardFriction = axleInfo.leftWheelCollider.forwardFriction;
            forwardFriction.stiffness = maxForwardFriction;
            axleInfo.leftWheelCollider.forwardFriction = forwardFriction;
            axleInfo.rightWheelCollider.forwardFriction = forwardFriction;
        }
    }

    void FixedUpdate() 
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);
        steeringWheelInput = state.ThumbSticks.Left.X; // Get steering wheel input (-1 to 1)
        acceleratorInput = state.Triggers.Right; // Get gas pedal input (0 to 1)
        brakeInput = state.Triggers.Left; // Get brake pedal input (0 to 1)

        // Rotate steering wheel game object by similar rotation of 
        // the physical steering wheel input device  
        if (steeringWheelObject != null) 
        {
            float rotationAngle = -steeringWheelInput * steeringWheelRotationMultiplier;
            Quaternion rotation = Quaternion.AngleAxis(rotationAngle, steeringWheelForward);
            steeringWheelObject.transform.localEulerAngles = new Vector3(0, 0, rotationAngle);
        }

        float motor = maxMotorTorque * acceleratorInput;
        float brakeMotor = maxMotorTorque * brakeInput; 
        float steering = maxSteeringAngle * steeringWheelInput; 

        foreach (AxleInfo axleInfo in axleInfos) 
        {
            if (axleInfo.steering) 
            {
                axleInfo.leftWheelCollider.steerAngle = steering;
                axleInfo.rightWheelCollider.steerAngle = steering;
            }

            if (axleInfo.motor) 
            {
                if (brakeInput > 0) {
                    // Apply negative motor torque to reverse the car
                    axleInfo.leftWheelCollider.motorTorque = -maxMotorTorque;
                    axleInfo.rightWheelCollider.motorTorque = -maxMotorTorque;
                } else {
                    // Apply positive motor torque to move the car forward
                    axleInfo.leftWheelCollider.motorTorque = motor; 
                    axleInfo.rightWheelCollider.motorTorque = motor; 
                }
                
                // Apply braking torque to the wheels when brake is pressed
                if (brakeInput > 0) 
                {
                    float brakeTorque = 0;
                    brakeTorque = brakeMotor * 0.5f;
                    axleInfo.leftWheelCollider.brakeTorque = brakeTorque;
                    axleInfo.rightWheelCollider.brakeTorque = brakeTorque;
                } else {
                    
                }
                

                // // Apply friction to the wheels to make the car feel less slippery
                // float frictionMultiplier = Mathf.Clamp01(rb.velocity.magnitude / 10);
                // WheelFrictionCurve sidewaysFriction = axleInfo.leftWheelCollider.sidewaysFriction;
                // sidewaysFriction.stiffness = maxSidewaysFriction * frictionMultiplier;
                // axleInfo.leftWheelCollider.sidewaysFriction = sidewaysFriction;
                // axleInfo.rightWheelCollider.sidewaysFriction = sidewaysFriction;

                // WheelFrictionCurve forwardFriction = axleInfo.leftWheelCollider.forwardFriction;
                // forwardFriction.stiffness = maxForwardFriction * frictionMultiplier;
                // axleInfo.leftWheelCollider.forwardFriction = forwardFriction;
                // axleInfo.rightWheelCollider.forwardFriction = forwardFriction;
            }

            ApplyLocalPositionToVisuals(axleInfo.leftWheelCollider);
            ApplyLocalPositionToVisuals(axleInfo.rightWheelCollider);
        }
    }
}
