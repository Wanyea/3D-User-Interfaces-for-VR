using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{ 
    public ArduinoManager arduinoManager;

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            arduinoManager.signalPin = 5;
            // arduinoManager.signalPin = -5;
        }
    }
}
