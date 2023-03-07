using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHandler : MonoBehaviour
{
    private OVRPlayerController controller;
    private float moveSpeedMultiplier = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<OVRPlayerController>();
        controller.SetMoveScaleMultiplier(moveSpeedMultiplier);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            Debug.Log("A was pressed");
            controller.Jump();
        }
    }
}
