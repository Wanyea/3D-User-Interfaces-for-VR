using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTransform : MonoBehaviour
{
    public Vector3 GetPlayerTransform() 
    {
        return gameObject.transform;
    }
}
