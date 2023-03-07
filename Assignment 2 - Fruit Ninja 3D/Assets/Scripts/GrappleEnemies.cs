using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleEnemies : MonoBehaviour
{
    Ray collisionRay;
    public GameObject visualRay;
    public GameObject lastHit;
    public Vector3 collision = Vector3.zero;
    public float grappleSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        collisionRay = new Ray(this.transform.position, this.transform.forward);    
        CheckForColliders();
    }

    // Update is called once per frame
    void Update()
    {
        collisionRay = new Ray(this.transform.position, this.transform.forward);  

        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))  
            CheckForColliders();
    }

    void CheckForColliders() 
    {
        if (Physics.Raycast(collisionRay, out RaycastHit hit, Mathf.Infinity)) 
        {
            lastHit = hit.transform.gameObject;
            collision = hit.point;
            Debug.DrawRay(transform.position, transform.forward, Color.green);

            if (hit.transform.gameObject.tag == "Enemy") 
            {
                Debug.Log("Tag is: " + lastHit.tag);
                Vector3 grappleDirection = (transform.position - hit.point);
                hit.rigidbody.velocity = grappleDirection.normalized * grappleSpeed; 
            }
        } else {
            Debug.DrawRay(transform.position, transform.forward, Color.red);
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(collision, 0.2f);    
    }
    
}
