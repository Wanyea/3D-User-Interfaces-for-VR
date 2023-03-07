using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float speed;
  
      public void Update()
      {
          float y = Mathf.PingPong(Time.time * speed, 1) * 6 - 3;
          apple.transform.position = new Vector3(0, y, 0);
      }
}
