using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;

public class ArduinoManager : MonoBehaviour 
{
  public string portName;
  public int colliderPin = 0;
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

  void SetPinState() 
  {

     // Set State For Pin 0
     if (colliderPin == 1) 
      {
        arduino.Write("1");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      } 

      if (colliderPin == -1) 
      {
        arduino.Write("-1");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      }

      // Set State For Pin 1
     if (colliderPin == 2) 
      {
        arduino.Write("2");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      } 

      if (colliderPin == -2) 
      {
        arduino.Write("-2");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      }

      // Set State For Pin 2
     if (colliderPin == 3) 
      {
        arduino.Write("3");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      } 

      if (colliderPin == -3) 
      {
        arduino.Write("-3");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      }

      // Set State For Pin 3
     if (colliderPin == 4) 
      {
        arduino.Write("4");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      } 

      if (colliderPin == -4) 
      {
        arduino.Write("-4");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      }

      // Set State For Pin 4
     if (colliderPin == 5) 
      {
        arduino.Write("5");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      } 

      if (colliderPin == -5) 
      {
        arduino.Write("-5");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      }

      // Set State For Pin 5
     if (colliderPin == 6) 
      {
        arduino.Write("6");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      } 

      if (colliderPin == -6) 
      {
        arduino.Write("-6");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      }

      // Set State For Pin 6
     if (colliderPin == 7) 
      {
        arduino.Write("7");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      } 

      if (colliderPin == -7) 
      {
        arduino.Write("-7");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      }

      // Set State For Pin 7
     if (colliderPin == 8) 
      {
        arduino.Write("8");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      } 

      if (colliderPin == -8) 
      {
        arduino.Write("-8");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      }

      // Set State For Pin 8
     if (colliderPin == 9) 
      {
        arduino.Write("9");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      } 

      if (colliderPin == -9) 
      {
        arduino.Write("-9");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      }

      // Set State For Pin 9
     if (colliderPin == 10) 
      {
        arduino.Write("10");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      } 

      if (colliderPin == -10) 
      {
        arduino.Write("-10");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      }

      // Set State For Pin 10
     if (colliderPin == 11) 
      {
        arduino.Write("11");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      } 

      if (colliderPin == -11) 
      {
        arduino.Write("-11");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      }

      // Set State For Pin 11
     if (colliderPin == 12) 
      {
        arduino.Write("12");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      } 

      if (colliderPin == -12) 
      {
        arduino.Write("-12");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      }

      // Set State For Pin 12
     if (colliderPin == 13) 
      {
        arduino.Write("13");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      } 

      if (colliderPin == -13) 
      {
        arduino.Write("-13");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      }

      // Set State For Pin 13
     if (colliderPin == 14) 
      {
        arduino.Write("14");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      } 

      if (colliderPin == -14) 
      {
        arduino.Write("-14");
        Debug.Log("Collider Pin is: " + colliderPin);
        colliderPin = 0;
      }
  }
}