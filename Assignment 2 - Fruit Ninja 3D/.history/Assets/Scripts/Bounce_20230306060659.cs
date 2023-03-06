using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float speed;
  
      public void Update()
      {
          float y = Mathf.PingPong(Time.time * speed, 1);
          transform.position = new Vector3(transform.position.x, y, transform.position.z);

      }
}
