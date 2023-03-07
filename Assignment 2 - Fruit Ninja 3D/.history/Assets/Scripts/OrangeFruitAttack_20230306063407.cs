using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeFruitAttack : MonoBehaviour
{
    public GameObject orangeBulletPrefab;
    [SerializeField] private float cooldown = 5.0;
    private float cooldownTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootAtPlayer();
    }

    void ShootAtPlayer() 
    {

    cooldownTimer -= Time.deltaTime;

    if(cooldownTimer > 0) return;

    cooldownTimer = cooldown;
     
    GameObject tempBullet = Instantiate(enemyBullet, eyes.gameObject.transform.position, eyes.gameObject.transform.rotation) as GameObject; //shoots from enemies eyes
    Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
    tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * enemyBulletSpeed);
    Destroy(tempBullet, 0.1f);

    }
}
