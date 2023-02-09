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

    // Enum where we set the mode of shooting the forceLightning
    public enum ShootMode
    {
        Auto,
        Single
    }

    [Header("ShootMethod")]
    // Choose the method of firing the forceLightnings from Inspector
    public ShootMode shootMode;

    // Boolean to use in single ShootMode
    private bool hasShoot = false;

    // Float used to calculate the time need to fire the forceLightning, related to the forceLightning fireRate
    private float timeToFire = 0f;

    // Method to add in the Event of the gesture you want to make shoot
    public void OnShoot()
    {
        if (Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1f / forceLightningPrefab.GetComponent<ProjectileScript>().fireRate;
            Shoot();
        }
    }

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

    private void activateForceLightning()
    {
        // In the End we will going to shoot force lightning
        GameObject forceLightning = Instantiate(forceLightningPrefab, hand.position, Quaternion.identity);
        forceLightning.transform.localRotation = hand.rotation;
        forceLightning.GetComponent<Rigidbody>().AddForce(forceLightning.transform.forward * speed * 2f); //Set the speed of the projectile by applying force to the rigidbody
    }

    // Method to put in the Event when the gesture are not recognized
    public void stopForceLightning()
    {
        hasShoot = false;
        Debug.Log("Stop Force Lightning");
    }

    public void SetMaxDistance(float distance)
    {
        maxDistance = distance;
    }
}