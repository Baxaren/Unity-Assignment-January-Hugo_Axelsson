using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerStateManager : MonoBehaviour
{
    public virtual void Awake() {
        Controller = GetComponent<CharacterController>();
        Input = GetComponent<PlayerInput>();

        PlayerSpeed = 1f;
        PlayerRotateSpeed = 180;

        GravityVector = new Vector3(0, -9.81f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateTowardsVector();
        ApplyGravity();
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




}
