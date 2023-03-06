using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject fruitEnemy;
    public Vector3 spawnPosition;

    void Awake() 
    {
        spawnPosition = new Vector3
        (
            transform.position.x,
            transform.position.y + 1.0f,
            transform.position.z
        );
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(fruitEnemy, new Vector3
        (
            transform.position.x,
            transform.position.y + 1.0f,
            transform.position.z
        ), Quaternion.identity);
    }

}
