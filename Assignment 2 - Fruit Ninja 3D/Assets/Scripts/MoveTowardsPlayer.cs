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
    int minDistance = 0;
    Transform playerTransform;

    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate() 
    {
       
        transform.LookAt(playerTransform.position);

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

