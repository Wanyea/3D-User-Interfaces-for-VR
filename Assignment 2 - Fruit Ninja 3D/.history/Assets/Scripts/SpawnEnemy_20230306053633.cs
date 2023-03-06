using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject fruitEnemy;
    public Vector3 spawnPosition;

    void Awake() 
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(fruitEnemy, spawnPosition, Quaternion.identity);
    }

}
