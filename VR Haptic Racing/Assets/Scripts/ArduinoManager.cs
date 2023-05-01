using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;

public class ArduinoManager : MonoBehaviour 
{
  public string portName;
  public int signalPin = 5; // Turns all pins off
  public int ledState = 0;
  public GameObject closestCar = null;
  [SerializeField] private GameObject playerVehicle;
  [SerializeField] private float maxDistance = 10f;
  

  SerialPort arduino;

  void Start() 
  {
    try {
      arduino = new SerialPort(portName, 115200);
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
        if (closestCar != null) 
        {
            SetPinIntensity(calculateDistance(closestCar));
        }
          

        if (signalPin == 5) 
        {
            // TURN ALL PINS OFF
        }
          
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
      // Set State For Pin 2
      if (signalPin == 1) 
      {
        arduino.Write("A");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 2);
        signalPin = 0;
      } 

      if (signalPin == -1) 
      {
        arduino.Write("a");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 2);
        signalPin = 0;
      }

      // Set State For Pin 3
      if (signalPin == 2) 
      {
        arduino.Write("B");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 3);
        signalPin = 0;
      } 

      if (signalPin == -2) 
      {
        arduino.Write("b");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 3);
        signalPin = 0;
      }

      // Set State For Pin 4
      if (signalPin == 3) 
      {
        arduino.Write("C");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 4);
        signalPin = 0;
      } 

      if (signalPin == -3) 
      {
        arduino.Write("c");
        Debug.Log("The Collider is: " + signalPin + " nd the corresponding pin is: " + 4);
        signalPin = 0;
      }

      // Set State For Pin 5
      if (signalPin == 4) 
      {
        arduino.Write("D");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 5);
        signalPin = 0;
      } 

      if (signalPin == -4) 
      {
        arduino.Write("-d");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 5);
        signalPin = 0;
      }

      // Set State For Pin 6
      if (signalPin == 5) 
      {
        arduino.Write("E");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 6);
        signalPin = 0;
      } 

      if (signalPin == -5) 
      {
        arduino.Write("e");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 6);
        signalPin = 0;
      }

      // Set State For Pin 7
      if (signalPin == 6) 
      {
        arduino.Write("F");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 7);
        signalPin = 0;
      } 

      if (signalPin == -6) 
      {
        arduino.Write("f");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 7);
        signalPin = 0;
      }

      // Set State For Pin 8
      if (signalPin == 7) 
      {
        arduino.Write("G");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 8);
        signalPin = 0;
      } 

      if (signalPin == -7) 
      {
        arduino.Write("g");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 8);
        signalPin = 0;
      }

      // Set State For Pin 9
      if (signalPin == 8) 
      {
        arduino.Write("H");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 9);
        signalPin = 0;
      } 

      if (signalPin == -8) 
      {
        arduino.Write("h");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 9);
        signalPin = 0;
      }

      // Set State For Pin 10
      if (signalPin == 9) 
      {
        arduino.Write("I");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 10);
        signalPin = 0;
      } 

      if (signalPin == -9) 
      {
        arduino.Write("i");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 10);
        signalPin = 0;
      }

      // Set State For Pin 11
      if (signalPin == 10) 
      {
        arduino.Write("J");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 11);
        signalPin = 0;
      } 

      if (signalPin == -10) 
      {
        arduino.Write("j");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 11);
        signalPin = 0;
      }

      // Set State For Pin 12
      if (signalPin == 11) 
      {
        arduino.Write("K");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 12);
        signalPin = 0;
      } 

      if (signalPin == -11) 
      {
        arduino.Write("k");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 12);
        signalPin = 0;
      }

      // Set State For Pin 13
      if (signalPin == 12) 
      {
        arduino.Write("L");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 13);
        signalPin = 0;
      } 

      if (signalPin == -12) 
      {
        arduino.Write("l");
        Debug.Log("The Collider is: " + signalPin + " and the corresponding pin is: " + 13);
        signalPin = 0;
      }

      // FOR RESETING ALL PINS (Turn all off)
      if (signalPin == 13) 
      {
        arduino.Write("O");
        Debug.Log("Turning all pins off...");
        signalPin = 0;
      }
  }
}
