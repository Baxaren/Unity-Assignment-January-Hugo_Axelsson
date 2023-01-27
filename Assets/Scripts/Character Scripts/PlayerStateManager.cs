using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerStateManager : MonoBehaviour
{
    public virtual void Awake() {  //Get character controller, inputs and set variables to standard values.
        Controller = GetComponent<CharacterController>();
        Input = GetComponent<PlayerInput>();

        PlayerSpeed = 0f;
        PlayerRotateSpeed = 180;

        GravityVector = new Vector3(0, -9.81f, 0);

        GravityValue = -9.81f;

        JumpHeight = 0f;
    }

    void Update()
    {
        Move();
        RotateTowardsVector();
        ApplyGravity();
        MovementJump();
    }

    public void ApplyGravity(){
        Controller.Move(GravityVector * Time.deltaTime);  //Apply Gravity with delta time
    }

    public virtual void Move(){
        Controller.Move(PlayerSpeed * MoveVector * Time.deltaTime);  //Apply movement with delta time
    }

    public virtual void RotateTowardsVector(){  //Rotates Character
        var xzDirection = new Vector3(MoveVector.x, 0, MoveVector.z);
        if (xzDirection.magnitude == 0 ) return;

        var rotation = Quaternion.LookRotation(xzDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, PlayerRotateSpeed);
    }

    void MovementJump(){  //Handles the Jump and makes it not work while in air.
        GroundedPlayer = Controller.isGrounded;

        if(GroundedPlayer){ // If on ground stop vertical movement.
            PlayerVelocity.y = 0.0f;
        }

        if(JumpPressed && GroundedPlayer){ // If jump pressed and on ground.
        PlayerVelocity.y += Mathf.Sqrt(JumpHeight * -1.0f * GravityValue);
        JumpPressed = false;
        }

        PlayerVelocity.y += GravityValue * Time.deltaTime;
        Controller.Move(PlayerVelocity * Time.deltaTime);
    }

    public virtual void OnJump(){  //Debug Tools for jump
        Debug.Log("Jump Pressed!");

        if(Controller.velocity.y == 0){
            Debug.Log("Can Jump");
            JumpPressed = true;

        }
        else{
            Debug.Log("Can't Jump");
        }
    }

    public virtual void OnAction(){  //Debug Tools for Action
        Debug.Log("Action Pressed");
    }

}
