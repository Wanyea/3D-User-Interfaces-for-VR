using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;

    public GameObject start;
    public GameObject end;
    bool alreadyAttacked;
    public GameObject projectile;

    public float speed = 0.5f;

    public float timeBetweenAttacks = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePracticeDroid();
        AttackPlayer();
    }

    public void movePracticeDroid() 
    {
        
            Debug.Log("Practice Droid not defeated yet");

            float time = Mathf.PingPong(Time.time * speed, 2);

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(start.transform.position, end.transform.position, time);
    
    }

    private void AttackPlayer()
    {

        transform.LookAt(player.transform);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.Euler(0f, 180f, 90f)).GetComponent<Rigidbody>();
            rb.AddForce(Vector3.forward * 32f, ForceMode.Impulse);
            rb.AddForce(Vector3.forward * 8f, ForceMode.Impulse);
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
