using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jumper : PlayerStateManager
{

public override void Awake() {
        Controller = GetComponent<CharacterController>();
        Input = GetComponent<PlayerInput>();
        PlayerSpeed = 15f;
        PlayerRotateSpeed = 180;

        GravityVector = new Vector3(0, -9.81f, 0);
    }

    public void Jump()
    {
        // something if enabled activate function ovverride this

        Debug.Log("I am Jumping!");


    }
}
