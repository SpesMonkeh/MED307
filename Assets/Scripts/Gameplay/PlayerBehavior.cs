using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using P307.Runtime.Inputs;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

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

    [SerializeField] private Camera _playerCam;

    private Vector3 _movement;
    
    
   

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        //Gets the player's rigidbody component
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    
    void Update()
    {
        
        _inputVector = new Vector2(_hInput, _vInput);
        //Setting the mouse input by using the floats to the x and y values times the sensitivity and time
        float mouseX = Input.GetAxis("Mouse X") * _sensX * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * _sensY * Time.deltaTime;
        float mouseY = 0f;
        
        

        Quaternion horizontalRotation = Quaternion.Euler(Vector3.up * mouseX);
        Quaternion verticalRotation = Quaternion.Euler(Vector3.left * mouseY);
        
        Quaternion newRotation = _rb.rotation * horizontalRotation * verticalRotation;
        
        _rb.MoveRotation(newRotation);
        
    }

    private void OnEnable()
    {
        InputEvents.HasMovementInput += OnMovementInput;
    }

    private void OnMovementInput(Vector2 obj, GameMode mode)
    {
        Vector2 norm = obj.normalized;
        _vInput = norm.x;
        _hInput = norm.y;
    }

    private void OnDisable()
    {
        InputEvents.HasMovementInput -= OnMovementInput;
    }

    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation*angleRot);
        
        
        //var cameraForward = Vector3.Scale(_playerCam.transform.forward, new Vector3(1, 0, 1)).normalized;
        var cameraForward = _playerCam.transform.forward;
        var cameraRight = _playerCam.transform.right;

        var moveDirection = (cameraForward * _inputVector.x + cameraRight * _inputVector.y).normalized;
        
        moveDirection.y = 0f;

        // Apply movement to the rigidbody
        _rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z) * _moveSpeed;
    }
    
    [SerializeField] private Vector2 _inputVector;

    
    }
   
    
    
    

