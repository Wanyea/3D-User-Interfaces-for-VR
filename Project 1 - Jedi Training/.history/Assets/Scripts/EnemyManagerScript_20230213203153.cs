using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public GameObject practiceDroid;
    public GameObject practiceDroidBullet;
    public GameObject enemyDroid;
    public GameObject enemyDroidBullet;
    public GameObject bossDroid;
    public GameObject bossDroidBullet;

    public GameObject practiceDroidSpawn;
    public GameObject enemyDroidSpawnOne;
    public GameObject enemyDroidSpawnTwo;
    public GameObject enemyDroidSpawnThree;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(practiceDroid, new Vector3(practiceDroidSpawn.position.x, practiceDroidSpawn.position.y + 10, practiceDroidSpawn.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        spawnFirstWave();
    }

    public void spawnFirstWave() 
    {
        if (!practiceDroid) 
        {
            Debug.Log("Practice Droid Defeated");
        }


    }
}
