using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacerController : MonoBehaviour
{
    public float maxMotorTorque = 400.0f;
    public float maxSteeringAngle = 30.0f;
    public float maxSpeed = 20.0f;
    public float minDistanceToObstacle = 5.0f;
    public float raycastOffset = 1.0f;

    private List<AxleInfo> axleInfos; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        axleInfos = new List<AxleInfo>();

        // Get all WheelCollider components attached to this object
        WheelCollider[] wheelColliders = GetComponentsInChildren<WheelCollider>();

        // Create an AxleInfo object for each pair of WheelColliders
        for (int i = 0; i < wheelColliders.Length; i += 2) 
        {
            AxleInfo axleInfo = new AxleInfo();
            axleInfo.leftWheelCollider = wheelColliders[i];
            axleInfo.rightWheelCollider = wheelColliders[i + 1];
            axleInfos.Add(axleInfo);
        }
    }

    void FixedUpdate() 
    {
        // Calculate inputs based on obstacles in front of car
        float motorInput = 1.0f;
        float steeringInput = 0.0f;

        // Check if there is an obstacle in front of the car
        RaycastHit hit;
        if (Physics.Raycast(transform.position + transform.forward * raycastOffset, transform.forward, out hit, minDistanceToObstacle)) 
        {
            // Calculate steering input based on obstacle position relative to car
            Vector3 hitPoint = hit.point - transform.position;
            hitPoint = Quaternion.Inverse(transform.rotation) * hitPoint;
            steeringInput = Mathf.Clamp(hitPoint.x / minDistanceToObstacle, -1.0f, 1.0f);

            // Brake if obstacle is too close
            if (hit.distance < minDistanceToObstacle / 2.0f) 
            {
                motorInput = -1.0f;
            }
        }

        // Apply inputs to wheels
        float motorTorque = maxMotorTorque * motorInput;
        float steeringAngle = maxSteeringAngle * steeringInput;
        float speed = rb.velocity.magnitude;
        if (speed > maxSpeed)
        {
            motorTorque = 0.0f;
        }

        foreach (AxleInfo axleInfo in axleInfos) 
        {
            if (axleInfo.steering) 
            {
                axleInfo.leftWheelCollider.steerAngle = steeringAngle;
                axleInfo.rightWheelCollider.steerAngle = steeringAngle;
            }

            if (axleInfo.motor) 
            {
                axleInfo.leftWheelCollider.motorTorque = motorTorque; 
                axleInfo.rightWheelCollider.motorTorque = motorTorque; 
            }

            ApplyLocalPositionToVisuals(axleInfo.leftWheelCollider);
            ApplyLocalPositionToVisuals(axleInfo.rightWheelCollider);
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
        visual
