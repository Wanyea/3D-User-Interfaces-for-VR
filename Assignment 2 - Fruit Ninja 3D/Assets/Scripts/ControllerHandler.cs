using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHandler : MonoBehaviour
{
    private OVRPlayerController controller;
    private float moveSpeedMultiplier = 3.0f;
    private bool isCrouching;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<OVRPlayerController>();
        controller.SetMoveScaleMultiplier(moveSpeedMultiplier);
        isCrouching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            Debug.Log("A was pressed");
            controller.Jump();
        }


        if (OVRInput.GetDown(OVRInput.Button.Two)) {
            Debug.Log("B was pressed");
            GameObject RightHand = GameObject.Find("RightHandAnchor");

            if (RightHand == null) {
                Debug.Log("RightHand is null?");
            } else {
                GameObject sword = RightHand.transform.GetChild(1).gameObject;
                GameObject shuriken = RightHand.transform.GetChild(2).gameObject;

                // Debug.Log("Sword's name is " + sword.name);
                // Debug.Log("Shuriken's name is " + shuriken.name);

                // if (!sword.activeSelf) {
                //     Debug.Log("Sword is currently inactive");
                // } else if (!shuriken.activeSelf) {
                //     Debug.Log("Shuriken is currently null");
                // }

                if (sword.activeSelf) {
                    sword.SetActive(false);
                    shuriken.SetActive(true);
                } else {
                    shuriken.SetActive(false);
                    sword.SetActive(true);
                }
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick)) {
            if (isCrouching) {
                gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                isCrouching = false;
            } else {
                gameObject.transform.localScale = new Vector3(1f, 0.5f, 1f);
                isCrouching = true;
            }
        }
    }
}
