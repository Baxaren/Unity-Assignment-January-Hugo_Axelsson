using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerStateManager
{
    public CharacterController Controller;
    public PlayerInput Input;
    public Vector3 MoveVector;
    public Vector2 InputVector;
    public float PlayerSpeed;
    public float PlayerRotateSpeed;
    public Vector3 GravityVector; //remove this later

    public float GravityValue;

    //Jump Variables
    public bool GroundedPlayer;

    public Vector3 PlayerVelocity;

    public float JumpHeight;
    private bool JumpPressed = false;

}
