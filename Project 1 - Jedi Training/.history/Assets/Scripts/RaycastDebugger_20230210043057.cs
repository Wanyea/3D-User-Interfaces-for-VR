using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDebugger : MonoBehaviour
{
    void FixedUpdate() 
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.red);    
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 1000, Color.green);    
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 1000, Color.blue);    


    }
}
