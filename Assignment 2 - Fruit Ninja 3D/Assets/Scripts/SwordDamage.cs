using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    [SerializeField] private AudioSource swordSlash;

    void OnCollisionEnter(Collision collision) 
    {
        swordSlash.Play();
    }
}
