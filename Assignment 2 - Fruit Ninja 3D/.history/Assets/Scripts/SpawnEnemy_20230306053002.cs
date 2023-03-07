using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject fruitEnemy;
    public Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector3
        (
            transform.position.x,
            transform.position.y + 1.0f,
            transform.position.z
        );

        Instantiate(fruitEnemy, spawnPosition, Quaternion.identity);
    }

}
