using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class SteeringWheelController : MonoBehaviour
{
    public float steeringWheelInput;
    private PlayerIndex playerIndex;
    private GamePadState state;
    private GamePadState prevState;

    // Start is called before the first frame update
    void Start()
    {
        playerIndex = PlayerIndex.One;
    }

    // Update is called once per frame
    void Update()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);
    }

    void FixedUpdate() 
    {
        steeringWheelInput = state.ThumbSticks.Left.X;
    }
}
