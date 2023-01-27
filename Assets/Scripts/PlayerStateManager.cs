using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerStateManager : MonoBehaviour
{
    public virtual void Awake() {
        Controller = GetComponent<CharacterController>();
        Input = GetComponent<PlayerInput>();

        PlayerSpeed = 0f;
        PlayerRotateSpeed = 180;

        GravityVector = new Vector3(0, -9.81f, 0);

        GravityValue = -9.81f;

        JumpHeight = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateTowardsVector();
        ApplyGravity();
        MovementJump();
    }

    public void ApplyGravity(){
        Controller.Move(GravityVector * Time.deltaTime);
    }

    public virtual void Move(){
        Controller.Move(PlayerSpeed * MoveVector * Time.deltaTime);
    }

    public virtual void RotateTowardsVector(){
        var xzDirection = new Vector3(MoveVector.x, 0, MoveVector.z);
        if (xzDirection.magnitude == 0 ) return;

        var rotation = Quaternion.LookRotation(xzDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, PlayerRotateSpeed);
    }

    void MovementJump(){
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

public virtual void OnJump(){
        Debug.Log("Jump Pressed!");

        if(Controller.velocity.y == 0){
            Debug.Log("Can Jump");
            JumpPressed = true;

        }
        else{
            Debug.Log("Can't Jump");
        }
    }

}
