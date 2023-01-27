using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pouncer : PlayerStateManager
{

public override void Awake() {
        Controller = GetComponent<CharacterController>();
        Input = GetComponent<PlayerInput>();
        PlayerSpeed = 5f;
        PlayerRotateSpeed = 180;

        GravityVector = new Vector3(0, -9.81f, 0);

        GravityValue = -9.81f;

        JumpHeight = 30f;
    }

    public void Pounce()
    {
        // something if enabled activate function

        Debug.Log("I am Pouncing!");


    }
}
