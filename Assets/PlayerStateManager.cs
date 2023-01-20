using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerStateManager : MonoBehaviour
{
    private void Awake() {
        Controller = GetComponent<CharacterController>();
        Input = GetComponent<PlayerInput>();
        PlayerSpeed = 10f;
        PlayerRotateSpeed = 180;

        GravityVector = new Vector3(0, -9.81f, 0);
    }



    // Start is called before the first frame update
    void Start()
    {
        
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

    public void Move(){
        Controller.Move(PlayerSpeed * MoveVector * Time.deltaTime);
    }

    public void RotateTowardsVector(){
        var xzDirection = new Vector3(MoveVector.x, 0, MoveVector.z);
        if (xzDirection.magnitude == 0 ) return;

        var rotation = Quaternion.LookRotation(xzDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, PlayerRotateSpeed);
    }




}
