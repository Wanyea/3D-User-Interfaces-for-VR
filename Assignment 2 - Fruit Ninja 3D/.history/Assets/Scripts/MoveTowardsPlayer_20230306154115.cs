using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float movementSpeed = 5.0f;
    Vector3 moveDirection;
    private Rigidbody rb;
    int maxDistance = 101;
    int minDistance = 5;
    Transform playerTransform;

    GetTransform getTransform;

    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
        getTransform = player.GetComponent<GetTransform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = getTransform.GetPlayerTransform();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 direction = (player.transform.position - transform.position).normalized;
        // float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        // rb.rotation = angle;
        // moveDirection = direction;
                playerTransform = getTransform.GetPlayerTransform();

                Debug.Log(platerTransform.position);

    }

    void FixedUpdate() 
    {
        // if (player) 
        // {
        //     rb.velocity = new Vector3(moveDirection) * movementSpeed;
        // }
        
        transform.LookAt(player.transform);

        if (Vector3.Distance(transform.position, player.transform.position) <= maxDistance)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= minDistance)
            {
            }
            else
            {
                transform.position += transform.forward * movementSpeed * Time.deltaTime;
            }

        }
        
    }
}

