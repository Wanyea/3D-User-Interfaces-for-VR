using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosition : MonoBehaviour
{
    public Vector3 GetPlayerPosition() 
    {
        return gameObject.transform.position;
    }
}
