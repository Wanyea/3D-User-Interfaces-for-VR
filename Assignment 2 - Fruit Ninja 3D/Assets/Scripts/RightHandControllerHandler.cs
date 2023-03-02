using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandControllerHandler : MonoBehaviour
{
    [SerializeField]
    float jetpackForce = 5f;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)) 
       {
        Debug.Log("A was pressed!");
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + jetpackForce, rb.velocity.z);
       }
    }
}
