using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 100.0f;

    public GameObject TwentyPercent;
    public GameObject FortyPercent;
    public GameObject SixtyPercent;
    public GameObject EightyPercent;
    public GameObject OneHundredPercent;

    // Update is called once per frame
    void Update()
    {
        ChangeHealthBar();
    }

    void ChangeHealthBar() 
    {
        if (playerHealth <= 80 && playerHealth > 60 && OneHundredPercent) 
        { OneHundredPercent.SetActive(false); } 

        if (playerHealth <= 60 && playerHealth > 40 && EightyPercent) 
        { EightyPercent.SetActive(false); } 

        if (playerHealth <= 40 && playerHealth > 20 && SixtyPercent) 
        { SixtyPercent.SetActive(false); } 

        if (playerHealth <= 20 && playerHealth > 0 && FortyPercent) 
        { FortyPercent.SetActive(false); } 

        if (playerHealth <= 0 && TwentyPercent) 
        { TwentyPercent.SetActive(false); } 
    }

    void OnCollisionEnter(Collision collision) 
    {
        Debug.Log("COLLISION WITH: " + collision.gameObject.name);

        if (collision.gameObject.name == "Orange Enemy(Clone)") 
        {
            playerHealth -= 25;
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
            playerHealth -= 10;
            Debug.Log("Player health is now: " + playerHealth);
        }

        if (collision.gameObject.name == "Pomegranate Enemy(Clone)") 
        {
            playerHealth -= 15;
            Debug.Log("Player health is now: " + playerHealth);
        }

        if (collision.gameObject.name == "Cookie") 
        {
            playerHealth += 20;
            Destroy(collision.gameObject);
            Debug.Log("Player health is now: " + playerHealth);
        }

        if (collision.gameObject.name == "Cake") 
        {
            playerHealth += 40;
            Destroy(collision.gameObject);
            Debug.Log("Player health is now: " + playerHealth);
        }
    }
}
