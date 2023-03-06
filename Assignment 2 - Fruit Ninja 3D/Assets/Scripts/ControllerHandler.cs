using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHandler : MonoBehaviour
{
    public Rigidbody rb;
    
    [SerializeField]
    float jetpackForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch)) 
        {
            Debug.Log("A was pressed!");
            rb.AddForce(0, jetpackForce, 0, ForceMode.Impulse);
            // rb.velocity += new Vector3(0, jetpackForce, 0);
        }
    }
}
