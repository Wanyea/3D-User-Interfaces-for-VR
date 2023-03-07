using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) 
    {
        Debug.Log("COLLISION WITH: " + collision.gameObject.name);
        if (collision.gameObject.name == "Orange Enemy(Clone)") 
        {
            playerHealth -= 20;
            Debug.Log("Player health is now: " + playerHealth);
        } 

        if (collision.gameObject.name == "Papaya Enemy(Clone)") 
        {
            playerHealth -= 15;
            Debug.Log("Player health is now: " + playerHealth);

        }

        if (collision.gameObject.name == "Strawberry Enemy(Clone)") 
        {
            playerHealth -= 5;
            Debug.Log("Player health is now: " + playerHealth);

        }

        if (collision.gameObject.name == "Dragon Fruit Enemy(Clone)") 
        {
            playerHealth -= 20;
            Debug.Log("Player health is now: " + playerHealth);
        }

        if (collision.gameObject.name == "Pomegranate Enemy(Clone)") 
        {
            playerHealth -= 10;
            Debug.Log("Player health is now: " + playerHealth);
        }


    }
}
