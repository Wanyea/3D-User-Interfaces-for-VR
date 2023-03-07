using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float movementSpeed = 5.0f;
    Vector3 moveDirection;
    private Rigidbody rb;

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
        Vector3 direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan3(direction.x, direction.y, direction.z) * Mathf.Rad2Deg;
        rb.rotation = angle;
        moveDirection = direction;
    }

    void FixedUpdate() 
    {
        if (player) 
        {
            rb.velocity = new Vector3(moveDirection) * movementSpeed;
        }
    }
}
