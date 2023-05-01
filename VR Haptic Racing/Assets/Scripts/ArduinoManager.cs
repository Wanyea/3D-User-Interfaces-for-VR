using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class ArduinoManager : MonoBehaviour 
{
  public string portName;
  public int signalPin = -5; // Turns all pins off
  public int ledState = 0;
  public GameObject closestCar = null;
  [SerializeField] private GameObject playerVehicle;
  [SerializeField] private float maxDistance = 13.0f;


  SerialPort arduino;

  void Start() 
  {
    try {
      arduino = new SerialPort(portName, 9600);
      arduino.Open();

      Debug.Log("Arduino port successfully opened!");
    } catch (Exception e) {
      Debug.Log("Unable to open Arduino port... Exception: " + e);
    }
  }
  
  void Update() 
  {
    if (arduino.IsOpen) 
    {
      SetPinState();    
    }
  }

  void SetPinIntensity(byte PWMvalue) 
  {

        byte[] arduinoData = new byte[] { (byte)signalPin, (byte) ledState, PWMvalue };

        Debug.Log("Sending the following byte to Arduino: " + "Signal Pin: " + arduinoData[0] + ", LED State: " + arduinoData[1] + ", PWM Value: " + arduinoData[2]);

        try
        {
            arduino.Write(arduinoData, 0, arduinoData.Length);
            Debug.Log("Arduino data successfully sent!");
        } catch (Exception ex) {
            Debug.Log("Arduino data was not sent... Exception: " + ex);
        }
  }
    

  byte calculateDistance(GameObject closestCar) 
  {
      float distance = Vector3.Distance(playerVehicle.transform.position, closestCar.transform.position);
      float normalizedDistance = distance / maxDistance;
      // Debug.Log("The distance between player and AI is: " + normalizedDistance);
      byte PWMvalue = (byte)Mathf.Lerp(0f, 255f, 1f - normalizedDistance);
      Debug.Log("The distance between player and AI is: " + distance);
          return PWMvalue;
    }

    void SetPinState()
    {
        if (signalPin == 1)
        {
            arduino.Write("A");
            Debug.Log("Turning on top motors...");
            signalPin = 0;
        }
        else if (signalPin == -1)
        {
            arduino.Write("a");
            Debug.Log("Turning off top motors...");
            signalPin = 0;
        }

        if (signalPin == 2)
        {
            arduino.Write("B");
            Debug.Log("Turning on right motors...");
            signalPin = 0;
        }
        else if (signalPin == -2)
        {
            arduino.Write("b");
            Debug.Log("Turning off right motors...");
            signalPin = 0;
        }

        if (signalPin == 3)
        {
            arduino.Write("C");
            Debug.Log("Turning on bottom motors...");
            signalPin = 0;
        }
        else if (signalPin == -3)
        {
            arduino.Write("c");
            Debug.Log("Turning off bottom motors...");
            signalPin = 0;
        }

        if (signalPin == 4)
        {
            arduino.Write("D");
            Debug.Log("Turning on left motors...");
            signalPin = 0;
        }
        else if (signalPin == -4)
        {
            arduino.Write("d");
            Debug.Log("Turning off left motors...");
            signalPin = 0;
        }

        if (signalPin == 5)
        {
            arduino.Write("E");
            Debug.Log("Turning on all motors...");
            signalPin = 0;
        }
        else if (signalPin == -5)
        {
            arduino.Write("e");
            Debug.Log("Turning off all motors...");
            signalPin = 0;
        }

    }
}
