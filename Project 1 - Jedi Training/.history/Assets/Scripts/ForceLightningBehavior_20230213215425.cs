using UnityEngine;

public class ForceLightningBehavior : MonoBehaviour
{
    // Damage done to enemies from the forceLightning
    public float damage = 20f; 
    
    // Speed of the force lightning
    public float speed = 20f;

    // The fire rate of the force lightning
    public float fireRate = 3f;

    // In float how many second have to pass before it destroy itself
    public float timeBeforeDestroyed = 5f;

    // The Rb of the Buller
    private Rigidbody rb = null;

    // GameObject that refer to the Impact effect
    [SerializeField] GameObject impactParticle;

    // GameObject that refer to the Muzzle effect
    [SerializeField] GameObject muzzleParticle;

    [Header("Adjust if not using Sphere Collider")]
    public float colliderRadius = 1f;
   
    [Range(0f, 1f)]
    public float collideOffset = 0.15f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, timeBeforeDestroyed);

        if (muzzleParticle)
        {
            muzzleParticle = Instantiate(muzzleParticle, transform.position, transform.rotation) as GameObject;
            Destroy(muzzleParticle, 1.5f); // Lifetime of muzzle effect.
        }
    }

    void FixedUpdate()
    {
        // Move the Rb of the force lightning forward in base at his speed
        if (speed != 0 && rb != null)
            rb.position += (transform.up) * (speed * Time.deltaTime);

        RaycastHit hit;

        float rad;
        if (transform.GetComponent<CapsuleCollider>())
            rad = transform.GetComponent<CapsuleCollider>().radius;
        else
            rad = colliderRadius;

        Vector3 dir = transform.GetComponent<Rigidbody>().velocity;
        if (transform.GetComponent<Rigidbody>().useGravity)
            dir += Physics.gravity * Time.deltaTime;
        dir = dir.normalized;

        float dist = transform.GetComponent<Rigidbody>().velocity.magnitude * Time.deltaTime;

        if (Physics.SphereCast(transform.position, rad, dir, out hit, dist))
        {
            transform.position = hit.point + (hit.normal * collideOffset);

            GameObject impactP = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, hit.normal)) as GameObject;

            if (hit.transform.tag == "EnemyDroid") // Projectile will destroy objects tagged as EnemyDroid
            {
                Destroy(hit.transform.gameObject);
            }

            Destroy(impactP, 5.0f);
            Destroy(gameObject);          
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.tag == "EnemyDroid") 
        {
            Destroy(other);
        }    
    }
}