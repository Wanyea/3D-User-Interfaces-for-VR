using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHandler : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float jetpackHeight;
    private float gravityValue = -9.81f;
    public float mass;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // // Walking
        // Vector2 rightControllerInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        // Vector3 move = new Vector3(rightControllerInput.x, 0, rightControllerInput.y);
        // controller.Move(move * Time.deltaTime * playerSpeed);

        // if (move != Vector3.zero)
        // {
        //     Debug.Log("We're moving!");
        //     gameObject.transform.forward = move;
        // }

        // Jetpack
        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch)) 
        {
            Debug.Log("A was pressed!");
            playerVelocity.y += Mathf.Sqrt(jetpackHeight * -mass * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
