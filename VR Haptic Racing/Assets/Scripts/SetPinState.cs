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
                    arduinoManager.signalPin = 3; // PWM Pin
                    arduinoManager.ledState = 1; // Turn pin on 
                        break;

                case "Right Collider":
                    arduinoManager.signalPin = 5; // PWM Pin
                    arduinoManager.ledState = 1; // Turn pin on 
                        break;

                case "Back Collider":
                    arduinoManager.signalPin = 6; // PWM Pin
                    arduinoManager.ledState = 1; // Turn pin on 
                        break;

                case "Left Collider":
                    arduinoManager.signalPin = 9; // PWM Pin
                    arduinoManager.ledState = 1; // Turn pin on 
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
                    arduinoManager.signalPin = 3; // PWM Pin
                    arduinoManager.ledState = -1; // Turn pin off 
                        break;

                case "Right Collider":
                    arduinoManager.signalPin = 5; // PWM Pin
                    arduinoManager.ledState = -1; // Turn pin off 
                        break;

                case "Back Collider":
                    arduinoManager.signalPin = 6; // PWM Pin
                    arduinoManager.ledState = -1; // Turn pin off 
                        break;

                case "Left Collider":
                    arduinoManager.signalPin = 9; // PWM Pin
                    arduinoManager.ledState = -1; // Turn pin off 
                        break;
            }

            arduinoManager.closestCar = null;
        }   
    }

}
