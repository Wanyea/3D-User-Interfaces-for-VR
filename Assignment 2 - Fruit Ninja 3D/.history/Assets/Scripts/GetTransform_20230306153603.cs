using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTransform : MonoBehaviour
{
    public Transform GetPlayerTransform() 
    {
        return gameObject.transform;
    }
}
