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
    private float min;
    private float max;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(practiceDroid, new Vector3(
            practiceDroidSpawn.transform.position.x, 
            practiceDroidSpawn.transform.position.y + 10, 
            practiceDroidSpawn.transform.position.z), 
            Quaternion.identity);

            min = transform.posiiton.z;
            max = transform.position.z + 5;
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

    public void movePracticeDroid() 
    {
        while(practiceDroid) 
        {
            
        }
    }
}
