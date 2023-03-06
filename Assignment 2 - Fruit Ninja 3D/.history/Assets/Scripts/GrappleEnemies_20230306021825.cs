using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleEnemies : MonoBehaviour
{
    Ray ray;
    public GameObject visualRay;
    public GameObject lastHit;
    public Vector3 collision = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray(this.transform.position, this.transform.forward);    
        CheckForColliders();
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(this.transform.position, this.transform.forward);    
        CheckForColliders();
    }

    void CheckForColliders() 
    {
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.infinity)) 
        {
            lastHit = hit.transform.gameObject;
            collision = hit.point;
            Debug.DrawRay(transform.position, transform.forward, Color.green);
            Debug.Log(lastHit.name + " was hit!");
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
