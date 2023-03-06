using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject fruitEnemyPrefab;
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
        GameObject instance = Instantiate(fruitEnemyPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        instance.transform.position = new Vector3 
            (
                transform.position.x,
                transform.position.y + 0.1f,
                transform.position.z
            );
    }

}
