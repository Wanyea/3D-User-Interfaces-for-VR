using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;

public class ArduinoManager : MonoBehaviour 
{
  public string portName;
  public int colliderPin = 13;
  public GameObject closestCar = null;
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
    if (arduino.IsOpen && closestCar != null) 
    {
      SetPinState();
    }
  }

  void SetPinIntensity() 
  {
    if(colliderPin == 1) 
    {

    }
  }

  byte calculateDistance() 
  {
      float distance = Vector3.Distance(transform.position, closestCar.transform.position);
      float normalizedDistance = distance / maxDistance;
      byte PWMvalue = (byte)Mathf.Lerp(0f, 255f, 1f - normalizedDistance);
          return PWMvalue;
  }

  void SetPinState() 
  {
      // Set State For Pin 2
      if (colliderPin == 1) 
      {
        arduino.Write("A");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 2);
        colliderPin = 0;
      } 

      if (colliderPin == -1) 
      {
        arduino.Write("a");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 2);
        colliderPin = 0;
      }

      // Set State For Pin 3
      if (colliderPin == 2) 
      {
        arduino.Write("B");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 3);
        colliderPin = 0;
      } 

      if (colliderPin == -2) 
      {
        arduino.Write("b");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 3);
        colliderPin = 0;
      }

      // Set State For Pin 4
      if (colliderPin == 3) 
      {
        arduino.Write("C");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 4);
        colliderPin = 0;
      } 

      if (colliderPin == -3) 
      {
        arduino.Write("c");
        Debug.Log("The Collider is: " + colliderPin + " nd the corresponding pin is: " + 4);
        colliderPin = 0;
      }

      // Set State For Pin 5
      if (colliderPin == 4) 
      {
        arduino.Write("D");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 5);
        colliderPin = 0;
      } 

      if (colliderPin == -4) 
      {
        arduino.Write("-d");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 5);
        colliderPin = 0;
      }

      // Set State For Pin 6
      if (colliderPin == 5) 
      {
        arduino.Write("E");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 6);
        colliderPin = 0;
      } 

      if (colliderPin == -5) 
      {
        arduino.Write("e");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 6);
        colliderPin = 0;
      }

      // Set State For Pin 7
      if (colliderPin == 6) 
      {
        arduino.Write("F");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 7);
        colliderPin = 0;
      } 

      if (colliderPin == -6) 
      {
        arduino.Write("f");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 7);
        colliderPin = 0;
      }

      // Set State For Pin 8
      if (colliderPin == 7) 
      {
        arduino.Write("G");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 8);
        colliderPin = 0;
      } 

      if (colliderPin == -7) 
      {
        arduino.Write("g");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 8);
        colliderPin = 0;
      }

      // Set State For Pin 9
      if (colliderPin == 8) 
      {
        arduino.Write("H");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 9);
        colliderPin = 0;
      } 

      if (colliderPin == -8) 
      {
        arduino.Write("h");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 9);
        colliderPin = 0;
      }

      // Set State For Pin 10
      if (colliderPin == 9) 
      {
        arduino.Write("I");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 10);
        colliderPin = 0;
      } 

      if (colliderPin == -9) 
      {
        arduino.Write("i");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 10);
        colliderPin = 0;
      }

      // Set State For Pin 11
      if (colliderPin == 10) 
      {
        arduino.Write("J");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 11);
        colliderPin = 0;
      } 

      if (colliderPin == -10) 
      {
        arduino.Write("j");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 11);
        colliderPin = 0;
      }

      // Set State For Pin 12
      if (colliderPin == 11) 
      {
        arduino.Write("K");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 12);
        colliderPin = 0;
      } 

      if (colliderPin == -11) 
      {
        arduino.Write("k");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 12);
        colliderPin = 0;
      }

      // Set State For Pin 13
      if (colliderPin == 12) 
      {
        arduino.Write("L");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 13);
        colliderPin = 0;
      } 

      if (colliderPin == -12) 
      {
        arduino.Write("l");
        Debug.Log("The Collider is: " + colliderPin + " and the corresponding pin is: " + 13);
        colliderPin = 0;
      }

      // FOR RESETING ALL PINS (Turn all off)
      if (colliderPin == 13) 
      {
        arduino.Write("O");
        Debug.Log("Turning all pins off...");
        colliderPin = 0;
      }
  }
}
