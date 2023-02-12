using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceWaveManager : MonoBehaviour
{
    [Header("Spawn Transform")]
    // Transform where the forceWave have to be Instantiated
    public Transform hand;

    [Header("Force Lightning Prefab")]
    // GameObject used as Force Lightning to Instatiate 
    [SerializeField] public GameObject forceWavePrefab;

    public float speed = 50f;
    public float yWaveOffset = 1.0f;
    public float lightningOffset = 1.0f;
    private float maxDistance = 100f;

    // Enum where we set the mode of shooting the forceWave
    public enum ShootMode
    {
        Auto,
        Single
    }

    [Header("Shoot Method")]
    // Choose the method of firing the forceWaves from Inspector
    public ShootMode shootMode;

    // Boolean to use in single ShootMode
    private bool hasShoot = false;

    // Float used to calculate the time need to fire the force lightning, related to the force lightning fireRate
    private float timeToFire = 0f;

    // Method to add in the Event of the gesture you want to make shoot
    public void OnShoot()
    {
        // Switch between the to modes
        switch (shootMode)
        {
            case ShootMode.Auto:
                Debug.Log("Shooting in Auto");
                if (Time.time >= timeToFire)
                {
                    timeToFire = Time.time + 1f / forceWavePrefab.GetComponent<ForceWaveBehavior>().fireRate;
                    Shoot();
                }
                break;

            case ShootMode.Single:
                if (!hasShoot)
                {
                    hasShoot = true;
                    Debug.Log("Shooting in Single");
                    Shoot();
                }
                break;
        }
    }

    void Update()
    {
        // RaycastHit hit;

        // if (Physics.Raycast(gunTip.position, gunTip.forward, out hit, maxDistance, whatCanCollide))
        // {
        //     circle.gameObject.SetActive(true);
        //     circle.position = (hit.point);
        //     circle.rotation = Quaternion.LookRotation(hit.normal);
        // }
        // else
        // {
        //     circle.gameObject.SetActive(false);
        // }
    }

    private void Shoot()
    {
        // In the End we will going to shoot a forceWave
        GameObject forceWave = Instantiate(forceWavePrefab, new Vector3(hand.position.x, hand.position.y + yLightningOffset, hand.position.z), Quaternion.identity);
        forceWave.transform.localRotation = hand.rotation;
        forceWave.GetComponent<Rigidbody>().AddForce(forceWave.transform.forward * speed * 2f); //Set the speed of the projectile by applying force to the rigidbody
    }

    // Method to put in the Event when the gesture are not recognized
    public void StopShoot()
    {
        hasShoot = false;
        Debug.Log("Stop Shooting");
    }

    public void SetMaxDistance(float distance)
    {
        maxDistance = distance;
    }
}
