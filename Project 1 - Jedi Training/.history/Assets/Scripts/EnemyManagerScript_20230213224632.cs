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
    public GameObject enemyDroidSpawnFour;

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

            Instantiate(enemyDroidTwo, new Vector3(
            enemyDroidSpawnTwo.transform.position.x, 
            enemyDroidSpawnTwo.transform.position.y + 15, 
            enemyDroidSpawnTwo.transform.position.z), 
            Quaternion.LookRotation(Vector3.left));

            Instantiate(enemyDroidThree, new Vector3(
            enemyDroidSpawnThree.transform.position.x, 
            enemyDroidSpawnThree.transform.position.y + 15, 
            enemyDroidSpawnThree.transform.position.z), 
            Quaternion.LookRotation(Vector3.left));

            Instantiate(enemyDroidFour, new Vector3(
            enemyDroidSpawnFour.transform.position.x, 
            enemyDroidSpawnFour.transform.position.y + 15, 
            enemyDroidSpawnFour.transform.position.z), 
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
