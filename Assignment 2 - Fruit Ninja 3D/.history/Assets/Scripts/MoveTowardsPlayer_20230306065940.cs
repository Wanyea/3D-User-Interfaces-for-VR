using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float movementSpeed = 5.0f;
    Vector3 moveDirection;
    private Rigidbody rb;
    int MaxDist = 101;
    int MinDist = 5;


    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 direction = (player.transform.position - transform.position).normalized;
        // float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        // rb.rotation = angle;
        // moveDirection = direction;
    }

    void FixedUpdate() 
    {
        // if (player) 
        // {
        //     rb.velocity = new Vector3(moveDirection) * movementSpeed;
        // }

        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.transform.position) <= MaxDist)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= MinDist)
            {
            }
            else
            {
                transform.position += transform.forward * movementSpeed * Time.deltaTime;
            }

        }
        
    }
}

