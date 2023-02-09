using UnityEngine;

public class ForceLightningManager : MonoBehaviour
{
    [Header("Spawn Transform")]
    // Transform where the forceLightning have to be Instantiated
    public Transform hand;

    [Header("Force Lightning Prefab")]
    // GameObject used as Force Lightning to Instatiate 
    [SerializeField] GameObject forceLightningPrefab;

    public LayerMask whatCanCollide;
    public int forceLightningCooldown = 5.0f;
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
    
    }

    // Method to put in the Event when the gesture are not recognized
    public void StopForceLightning()
    {
        Debug.Log("Stop Force Lightning in " + forceLightningCooldown + " seconds...");
        Destroy(forceLightning, forceLightningCooldown);
        Debug.Log("Force Lightning deactivated!")
    }
}