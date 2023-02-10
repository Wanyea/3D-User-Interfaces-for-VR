using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDebugger : MonoBehaviour
{
    void private void FixedUpdate() 
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);    
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);    

    }
}
