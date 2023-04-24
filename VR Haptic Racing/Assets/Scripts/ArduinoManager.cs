using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;

public class ArduinoManager : MonoBehaviour 
{
  public string portName;
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
      if (Input.GetKey("up")) {
        arduino.Write("1");
        Debug.Log(1);
      } else if (Input.GetKey("down")) {
        arduino.Write("0");
        Debug.Log(0);
      }

       // Debug.Log("Arduino Open");
    }
  }
}