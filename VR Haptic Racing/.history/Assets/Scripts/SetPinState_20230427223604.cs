using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetPinState : MonoBehaviour
{
    public ArduinoManager arduinoManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider) 
    {
        if (collider.tag == "Enemy Cars")
            arduinoManager.colliderPin = Int32.Parse(gameObject.name);
    }

    private void OnTriggerExit(Collider collider) 
    {
        if (collider.tag == "Enemy Cars")
            arduinoManager.colliderPin = -1 * Int32.Parse(gameObject.name);
    }

}
