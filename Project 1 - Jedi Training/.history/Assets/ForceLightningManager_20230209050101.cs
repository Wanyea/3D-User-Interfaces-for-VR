using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class ForceLightningManager : MonoBehaviour
{
    [Header("Spawn Transform")]
    // Transform where the forceLightning have to be Instantiated
    public Transform hand;

    [Header("Force Lightning Prefab")]
    // GameObject used as Force Lightning to Instatiate 
    [SerializeField] public GameObject forceLightningPrefab;

    public LayerMask whatCanCollide;
    public float forceLightningCooldown = 5.0f;
    private bool isForceLightningActive = false;
    private GameObject forceLightning;


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

    // Method that will be called when gesture is made --> starts force lightning.
    public void StartForceLightning()
    {
        forceLightning = Instantiate(forceLightningPrefab, hand.position, Quaternion.identity);
        forceLightning.transform.localRotation = hand.rotation;

        isForceLightningActive = true;
        Debug.Log("Force Lightning Activated!");

    }

    // Method to put in the Event when the gesture are not recognized
    public void StopForceLightning()
    {
        if(isForceLightningActive) 
        {
            Destroy(forceLightningPrefab);
            isForceLightningActive = false;
            Debug.Log("Force Lightning deactivated!");

        }
    }
}