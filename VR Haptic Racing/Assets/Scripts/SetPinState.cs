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

        // if (gameObject.name == "1") 
        // {
        //     arduinoManager.colliderPin = 1;
        // }

        // if (gameObject.name == "2") 
        // {
        //     arduinoManager.colliderPin = 2;
        // }

        // if (gameObject.name == "3") 
        // {
        //     arduinoManager.colliderPin = 3;
        // }

        // if (gameObject.name == "4") 
        // {
        //     arduinoManager.colliderPin = 4;
        // }

        // if (gameObject.name == "5") 
        // {
        //     arduinoManager.colliderPin = 5;
        // }

        // if (gameObject.name == "6") 
        // {
        //     arduinoManager.colliderPin = 6;
        // }

        
        // if (gameObject.name == "7") 
        // {

        // }

        // if (gameObject.name == "8") 
        // {

        // }

        // if (gameObject.name == "9") 
        // {

        // }

        // if (gameObject.name == "10") 
        // {

        // }

        // if (gameObject.name == "11") 
        // {

        // }

        // if (gameObject.name == "12") 
        // {

        // }
    }

    private void OnTriggerExit(Collider collider) 
    {
        // if (gameObject.name == "N - 1") 
        // {
        //     arduinoManager.colliderPin = 1;
        // }
        if (collider.tag == "Enemy Cars")
            arduinoManager.colliderPin = -1 * Int32.Parse(gameObject.name);
    }

}
