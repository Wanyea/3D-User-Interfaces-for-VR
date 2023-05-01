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
            switch (gameObject.name) 
            {
                case "Front Trigger":
                    arduinoManager.signalPin = 1; // PWM Pin
                        break;

                case "Right Trigger":
                    arduinoManager.signalPin = 2; // PWM Pin
                        break;

                case "Back Trigger":
                    arduinoManager.signalPin = 3; // PWM Pin
                        break;

                case "Left Trigger":
                    arduinoManager.signalPin = 4; // PWM Pin
                        break;
            }

            if (arduinoManager.closestCar == null)
                arduinoManager.closestCar = collider.gameObject;
        }         
    }

    private void OnTriggerExit(Collider collider) 
    {
        if (collider.tag == "Enemy Cars") 
        {
            switch (gameObject.name)
            {
                case "Front Trigger":
                    arduinoManager.signalPin = -1; // PWM Pin
                    break;

                case "Right Trigger":
                    arduinoManager.signalPin = -2; // PWM Pin
                    break;

                case "Back Trigger":
                    arduinoManager.signalPin = -3; // PWM Pin
                    break;

                case "Left Trigger":
                    arduinoManager.signalPin = -4; // PWM Pin
                    break;
            }

            arduinoManager.closestCar = null;
        }   
    }

}
