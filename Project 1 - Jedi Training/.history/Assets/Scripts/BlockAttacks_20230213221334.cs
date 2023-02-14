using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAttacks : MonoBehaviour
{

    public AudioSource blockedAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "EnemyBullet") 
        {
            Destroy(other.gameObject);
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
        }
    }
}
