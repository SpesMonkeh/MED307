using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Floats for the player's movement and rotation speed
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    // Floats containing input values
    private float _vInput;
    private float _hInput;

    // Floats containing rotations values
    private float _xRotation;
    private float _yRotation;

    // Floats containing move sensitivity
    [SerializeField] private float _sensX;
    [SerializeField] private float _sensY;

    //Rigidbody
    private Rigidbody _rb;

    
    
    
    void Start()
    {
        //Gets the player's rigidbody component
        _rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        //Setting the input value to the values from Input Manager's vertical and horizontal values times the speed.
        _vInput = Input.GetAxis("Vertical");
        _hInput = Input.GetAxis("Horizontal");

        _inputVector = new Vector2(_vInput, _hInput);
        //Setting the mouse input by using the floats to the x and y values times the sensitivity and time
        float mouseX = Input.GetAxis("Mouse X") * _sensX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensY * Time.deltaTime;
        

        // Rotating the rigidbody based on the rotation from the vertical and horizontal angles times the mouse input
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(Vector3.left * mouseY));
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(Vector3.up * mouseX));
    }

    
    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        MoveCharacter();
        _rb.MoveRotation(_rb.rotation*angleRot);
    }
    
    [SerializeField] private Vector2 _inputVector;


    private Vector3 Up;
    
    void MoveCharacter()
    {
        var moveVector = new Vector3(_inputVector.y, 0, _inputVector.x);
        //_rb.AddForce(moveVector*_moveSpeed);
        Up = new Vector3(0, _rb.velocity.y, 0f);
        var a = transform.InverseTransformDirection(transform.forward);
        var b = transform.InverseTransformDirection(transform.right);
        _rb.velocity = (a * _vInput + b * _hInput).normalized * _moveSpeed + Up;

    }
   
    
    
    
}
