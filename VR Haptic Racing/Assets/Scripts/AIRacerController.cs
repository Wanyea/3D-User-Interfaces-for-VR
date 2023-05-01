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
    public Vector3 centerOfMassOffset = new Vector3(0, -0.5f, 0);
    private Rigidbody rb;
    private int currentWaypointIndex = 0;
    [SerializeField] private List<AxleInfo> axleInfos;
    [SerializeField] private List<Vector3> waypoints;
    public float maxSidewaysFriction = 2.0f;
    public float maxForwardFriction = 1.5f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass += centerOfMassOffset;

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

            waypoints.Clear();

            Vector3 initialWaypoint = transform.position + 2.0f * transform.forward;
            waypoints.Add(initialWaypoint); // Add first point right in front of the AI.
        }
    }

    void FixedUpdate()
    {
        // Debug.Log(currentWaypointIndex);

        // Calculate the direction to the current waypoint
        Vector3 targetDirection = waypoints[currentWaypointIndex] - transform.position;
        targetDirection.y = 0f;
        targetDirection.Normalize();

        // Calculate the angle between the car's forward vector and the target direction
        float angle = Vector3.SignedAngle(transform.forward, targetDirection, Vector3.up);

        // Adjust the steering angle to point towards the current waypoint
        float steering = Mathf.Clamp(angle, -maxSteerAngle, maxSteerAngle);

        // If we've reached the current waypoint, move to the next one
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex]) < 1f)
        {
            GenerateNextWayPoint();
            currentWaypointIndex++;
        }

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

    public void GenerateNextWayPoint()
    {

        float waypointDistance = 2.5f; // Change this to set the distance between waypoints

        Vector3 carPos = transform.position; // Get the position of the car

        // Get the direction the car is facing
        Vector3 carForward = transform.forward;
        carForward.y = 0f;
        carForward.Normalize();

        // Start at the car's position and add waypoints in front of it
        Vector3 currentPos = carPos;

        // Get a random point in front of the car
        Vector3 randomOffset = new Vector3(Random.Range(0f, 0.5f), 0f, Random.Range(0.5f, 1f));
        Vector3 nextPos = currentPos + carForward * waypointDistance + randomOffset;

        // Use a raycast to check if the next waypoint is on the racetrack
        RaycastHit hit;
        if (Physics.Raycast(nextPos + Vector3.up * 10f, Vector3.down, out hit, 100f, layerMask))
        {
            // Debug.Log("Waypoint on track! Adding it to list...");
            // Add the waypoint to the list if it's on the racetrack
            waypoints.Add(hit.point);
            currentPos = hit.point;
        } else {
            // Debug.Log("Waypoint not on track. Steering back towards road...");
            // The point is not on the racetrack, steer back towards the center of the road
            Vector3 center = transform.position;
            center.y = hit.point.y;
            Vector3 direction = center - hit.point;
            Vector3 normal = Vector3.Cross(direction, Vector3.up);
            Vector3 targetPoint = hit.point + normal.normalized * Random.Range(1f, 5f);
            waypoints.Add(targetPoint);
            currentPos = targetPoint;
        }
     
    }
}
