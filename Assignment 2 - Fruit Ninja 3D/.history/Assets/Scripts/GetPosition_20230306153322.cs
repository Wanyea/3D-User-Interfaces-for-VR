using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTransform : MonoBehaviour
{
    public Vector3 GetPlayerPosition() 
    {
        return gameObject.transform;
    }
}
