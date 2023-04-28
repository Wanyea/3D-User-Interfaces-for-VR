using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacerController : MonoBehaviour
{
    public float maxSteerAngle = 45f;
    public float maxMotorTorque = 100f;
    public float maxBrakeTorque = 100f;
    public float maxSpeed = 100f;
    public float safeDistance = 10f;
    public float avoidMultiplier = 10f;
    public float raycastRange = 20f;
    public LayerMask layerMask;
    public List<AxleInfo> axleInfos;
    public Vector3 centerOfMassOffset = new Vector3(0.5f, -0.5f, 0);


    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass += centerOfMassOffset;
    }

    void FixedUpdate()
    {
        float motor = maxMotorTorque;
        float steering = maxSteerAngle;

        // Check the raycasts in front of the car
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastRange, layerMask))
        {
            // Check the distance between the car and the obstacle
            float distance = hit.distance;
            if (distance <= safeDistance)
            {
                // Avoid the obstacle
                steering = hit.normal.x * avoidMultiplier;
                motor = 0f;
            }
        }

        // Move the car forward
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.motor)
            {
                axleInfo.leftWheelCollider.motorTorque = motor;
                axleInfo.rightWheelCollider.motorTorque = motor;
            }

            if (axleInfo.steering)
            {
                axleInfo.leftWheelCollider.steerAngle = steering;
                axleInfo.rightWheelCollider.steerAngle = steering;
            }

            ApplyLocalPositionToVisuals(axleInfo.leftWheelCollider);
            ApplyLocalPositionToVisuals(axleInfo.rightWheelCollider);
        }

        // Apply brakes if the car is moving too fast
        if (rb.velocity.magnitude > maxSpeed)
        {
            foreach (AxleInfo axleInfo in axleInfos)
            {
                if (axleInfo.motor)
                {
                    axleInfo.leftWheelCollider.brakeTorque = maxBrakeTorque;
                    axleInfo.rightWheelCollider.brakeTorque = maxBrakeTorque;
                }
            }
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
