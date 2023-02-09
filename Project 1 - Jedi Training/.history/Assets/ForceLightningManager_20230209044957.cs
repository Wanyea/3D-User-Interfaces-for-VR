using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class ForceLightningManager : MonoBehaviour
{
    [Header("SpawnTransform")]
    // Transform where the forceLightning have to be Instantiated
    public Transform hand;

    [Header("ForceLightningPrefab")]
    // GameObject used as Force Lightning to Instatiate 
    [SerializeField] public GameObject forceLightningPrefab;

    public LayerMask whatCanCollide;
    public float forceLightningCooldown = 5.0f;
    private bool isForceLightningActive = false;


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
    private void StartForceLightning()
    {
        Debug.Log("Force Lightning Activated!");
        GameObject forceLightning = Instantiate(forceLightningPrefab, hand.position, Quaternion.identity);
        forceLightning.transform.localRotation = hand.rotation;

        isForceLightningActive = true;

        if (isForceLightningActive)
            Destroy(forceLightning, forceLightningCooldown);
    }

    // Method to put in the Event when the gesture are not recognized
    public void StopForceLightning()
    {
        if(isForceLightningActive) 
        {
            
        }
        Debug.Log("Force Lightning deactivated!");
    }
}