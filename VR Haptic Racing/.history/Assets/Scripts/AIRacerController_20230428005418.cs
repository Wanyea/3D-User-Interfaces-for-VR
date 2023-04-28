using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacerController : MonoBehaviour
{
    public float maxSteerAngle = 150f;
    public float maxMotorTorque = 100f;
    public float maxBrakeTorque = 100f;
    public float maxSpeed = 100f;
    public float safeDistance = 10f;
    public float avoidMultiplier = 10f;
    public float raycastRange = 20f;
    public LayerMask layerMask;
    public Vector3 centerOfMassOffset = new Vector3(0.5f, -0.5f, 0);
    private Rigidbody rb;
    private int currentWaypointIndex = 0;
    [SerializeField] private List<AxleInfo> axleInfos;
    [SerializeField] private List<Transform> waypoints = new List<Transform>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass += centerOfMassOffset;

        // TODO: Add waypoints
    }

    void FixedUpdate()
    {
        // If there are no waypoints, do nothing
        if (waypoints.Count == 0)
        {
            return;
        }

        // If we've reached the current waypoint, move to the next one
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }

        // Calculate the direction to the current waypoint
        Vector3 targetDirection = waypoints[currentWaypointIndex].position - transform.position;
        targetDirection.y = 0f;
        targetDirection.Normalize();

        // Calculate the angle between the car's forward vector and the target direction
        float angle = Vector3.SignedAngle(transform.forward, targetDirection, Vector3.up);

        // Adjust the steering angle to point towards the current waypoint
        float steering = Mathf.Clamp(angle, -maxSteerAngle, maxSteerAngle);

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
            }
        }
        // Move the car forward
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.motor)
            {
                axleInfo.leftWheelCollider.motorTorque = maxMotorTorque;
                axleInfo.rightWheelCollider.motorTorque = maxMotorTorque;
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
