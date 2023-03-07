using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100.0f;


    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "PlayerWeapon") 
        {
            enemyHealth -= 10.0f;

            if (enemyHealth == 0 ) 
            {
                Destroy(this.gameObject);
                
            }
            Debug.Log(collision.gameObject.name + "health is now " + enemyHealth);
        }
    }
}
