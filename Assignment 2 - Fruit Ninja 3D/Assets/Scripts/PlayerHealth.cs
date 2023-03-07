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
        if (collision.gameObject.name == "Orange Enemy") 
        {
            playerHealth -= 20;
            Debug.Log("Player health is now: " + playerHealth);
        } 

        if (collision.gameObject.name == "Papaya Enemy") 
        {
            playerHealth -= 15;
            Debug.Log("Player health is now: " + playerHealth);

        }

        if (collision.gameObject.name == "Strawberry Enemy") 
        {
            playerHealth -= 5;
            Debug.Log("Player health is now: " + playerHealth);

        }

        if (collision.gameObject.name == "Dragon Fruit Enemy") 
        {
            playerHealth -= 20;
            Debug.Log("Player health is now: " + playerHealth);
        }

        if (collision.gameObject.name == "Pomegranate Enemy") 
        {
            playerHealth -= 10;
            Debug.Log("Player health is now: " + playerHealth);
        }


    }
}
