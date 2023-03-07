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
            enemyHealth -= 20.0f;
            Debug.Log(this.gameObject.name + "health is now " + enemyHealth);

            if (enemyHealth == 0 ) 
            {
                Destroy(this.gameObject);
            }

        }
    }
}
