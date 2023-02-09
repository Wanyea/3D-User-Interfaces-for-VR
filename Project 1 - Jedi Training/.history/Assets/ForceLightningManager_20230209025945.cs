using UnityEngine;

public class ForceLightningManager : MonoBehaviour
{
    [Header("Spawn Transform")]

    // Transform where the forceLightning have to be Instantiated
    public Transform hand;

    [Header("Force Lightning Prefab")]

    // GameObject used as Force Lightning to Instatiate 
    [SerializeField] GameObject forceLightningPrefab;
    public float speed = 50f;

    [Header("Aim Circle")]
    public Transform gunTip;
    public Transform circle;

    private float maxDistance = 100f;
    public LayerMask whatCanCollide;

    private bool isForceLightningActive = false;

    // Float used to calculate the time need to fire the forceLightning, related to the forceLightning fireRate
    private float timeToFire = 0f;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(gunTip.position, gunTip.forward, out hit, maxDistance, whatCanCollide))
        {
            circle.gameObject.SetActive(true);
            circle.position = (hit.point);
            circle.rotation = Quaternion.LookRotation(hit.normal);
        }
        else
        {
            circle.gameObject.SetActive(false);
        }
    }

    // Method that will be called when 
    private void startForceLightning()
    {
        // In the End we will going to shoot force lightning
        GameObject forceLightning = Instantiate(forceLightningPrefab, hand.position, Quaternion.identity);
        forceLightning.transform.localRotation = hand.rotation;
        //forceLightning.GetComponent<Rigidbody>().AddForce(forceLightning.transform.forward * speed * 2f); //Set the speed of the projectile by applying force to the rigidbody
    }

    // Method to put in the Event when the gesture are not recognized
    public void stopForceLightning()
    {
        isForceLightningActive = false;
        Debug.Log("Stop Force Lightning");
    }

    public void SetMaxDistance(float distance)
    {
        maxDistance = distance;
    }
}