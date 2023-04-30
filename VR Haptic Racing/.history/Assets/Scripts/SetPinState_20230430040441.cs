using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetPinState : MonoBehaviour
{
    public ArduinoManager arduinoManager;

    private void OnTriggerEnter(Collider collider) 
    {
        if (collider.tag == "Enemy Cars") 
        {
            arduinoManager.colliderPin = Int32.Parse(gameObject.name);

            if (arduinoManager.closestCar == null)
                arduinoManager.closestCar = collider.gameObject;
        }         
    }

    private void OnTriggerExit(Collider collider) 
    {
        if (collider.tag == "Enemy Cars") 
        {
            arduinoManager.colliderPin = -1 * Int32.Parse(gameObject.name);
            arduinoManager.closestCar = null;
        }   
    }

}
