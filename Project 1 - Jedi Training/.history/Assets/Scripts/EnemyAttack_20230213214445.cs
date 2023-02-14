using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;

    public GameObject start;
    public GameObject end;
    bool alreadyAttacked;
    public GameObject projectile;

    public float speed = 1.0f;

    public float timeBetweenAttacks = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePracticeDroid();
    }

    public void movePracticeDroid() 
    {
        
            Debug.Log("Practice Droid not defeated yet");

            float time = Mathf.PingPong(Time.time * speed, 1);

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(start.position, end.position, time);
    
    }

    private void AttackPlayer()
    {

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
