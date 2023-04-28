using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacerController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; 
    public Vector3 centerOfMassOffset = new Vector3(0.5f, -0.5f, 0);
    public float maxMotorTorque = 400.0f;
    public float maxSteeringAngle = 30.0f;
    public float sensorLength = 5.0f;
    public float sensorAngle = 30.0f;
    private Rigidbody rb;
    private float steeringWheelInput;
    private float acceleratorInput;
    private float brakeInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        // Get sensor input
        float leftSensorInput = GetSensorInput(-sensorAngle);
        float rightSensorInput = GetSensorInput(sensorAngle);
        float centerSensorInput = GetSensorInput(0);

        // Calculate desired steering angle
        float steering = 0.0f;
        if (centerSensorInput > 0)
        {
            steering = Mathf.Clamp((rightSensorInput - leftSensorInput) / centerSensorInput, -1.0f, 1.0f);
        }

        // Calculate desired motor torque
        float motor = maxMotorTorque * centerSensorInput;

        // Apply steering and motor torque to wheels
        foreach (AxleInfo axleInfo in axleInfos) 
        {
            if (axleInfo.steering) 
            {
                axleInfo.leftWheelCollider.steerAngle = steering * maxSteeringAngle;
                axleInfo.rightWheelCollider.steerAngle = steering * maxSteeringAngle;
            }

            if (axleInfo.motor) 
            {
                axleInfo.leftWheelCollider.motorTorque = motor; 
                axleInfo.rightWheelCollider.motorTorque = motor; 
                axleInfo.leftWheelCollider.brakeTorque = 0;
                axleInfo.rightWheelCollider.brakeTorque = 0;
            }

            ApplyLocalPositionToVisuals(axleInfo.leftWheelCollider);
            ApplyLocalPositionToVisuals(axleInfo.rightWheelCollider);
        }
    }

    // Cast a ray to detect obstacles
    private float GetSensorInput(float angle)
    {
        RaycastHit hit;
        Vector3 sensorStartPos = transform.position + transform.forward * 1.5f;
        Quaternion sensorRotation = Quaternion.AngleAxis(angle, transform.up);
        Vector3 sensorDirection = sensorRotation * transform.forward;

        if (Physics.Raycast(sensorStartPos, sensorDirection, out hit, sensorLength))
        {
            Debug.DrawLine(sensorStartPos, hit.point, Color.red);
            return (sensorLength - hit.distance) / sensorLength;
        }
        else
        {
            Debug.DrawRay(sensorStartPos, sensorDirection * sensorLength, Color.green);
            return 0.0f;
        }
    }

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
}
