using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public GameObject practiceDroid;
    public GameObject enemyDroidOne;
    public GameObject enemyDroidTwo;
    public GameObject enemyDroidThree;
    public GameObject enemyDroidFour;
    public GameObject bossDroid;
 

    public GameObject practiceDroidSpawn;
    public GameObject enemyDroidSpawnOne;
    public GameObject enemyDroidSpawnTwo;
    public GameObject enemyDroidSpawnThree;
    public GameObject enemyDroidSpawnThree;

    public Transform start;
    public Transform end;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(practiceDroid, new Vector3(
            practiceDroidSpawn.transform.position.x, 
            practiceDroidSpawn.transform.position.y + 15, 
            practiceDroidSpawn.transform.position.z), 
            Quaternion.LookRotation(Vector3.left));

            Instantiate(enemyDroidOne, new Vector3(
            enemyDroidSpawnOne.transform.position.x, 
            enemyDroidSpawnOne.transform.position.y + 15, 
            enemyDroidSpawnOne.transform.position.z), 
            Quaternion.LookRotation(Vector3.left));

            Instantiate(enemyDroidOne, new Vector3(
            enemyDroidSpawnOne.transform.position.x, 
            enemyDroidSpawnOne.transform.position.y + 15, 
            enemyDroidSpawnOne.transform.position.z), 
            Quaternion.LookRotation(Vector3.left));

    }

    // Update is called once per frame
    void Update()
    {
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
