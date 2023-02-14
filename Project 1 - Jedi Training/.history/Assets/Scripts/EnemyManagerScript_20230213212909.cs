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

    public Transform start;
    public Transform end;


    private float min;
    private float max;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(practiceDroid, new Vector3(
            practiceDroidSpawn.transform.position.x, 
            practiceDroidSpawn.transform.position.y + 10, 
            practiceDroidSpawn.transform.position.z), 
            Quaternion.identity);

            min = transform.position.z;
            max = transform.position.z + 5;


    }

    // Update is called once per frame
    void Update()
    {
        movePracticeDroid();
        spawnFirstWave();
    }

    public void spawnFirstWave() 
    {
        if (practiceDroid == null) 
        {
            Debug.Log("Practice Droid Defeated");
        }


    }

}
