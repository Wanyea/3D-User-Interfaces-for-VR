using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleEnemies : MonoBehaviour
{
    //public Transform playerLeftHand;

    float timeElapsed;
    float lerpDuration = 3;
    public float speed = 1.0f;

    public Vector3 velocity = Vector3.zero;

    GetPosition getPosition;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToPlayer() 
    {
        getPosition = GameObject.Find("LeftControllerHand").GetComponent<GetPosition>();
        Debug.Log(gameObject.name + " has been selected!" + " Player position is: " + getPosition.GetPlayerPosition());

        while (timeElapsed < lerpDuration)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, getPosition.GetPlayerPosition(), speed * Time.deltaTime);
            timeElapsed += Time.deltaTime;
        }

        //gameObject.transform.position = getPosition.GetPlayerPosition();

    }
}
