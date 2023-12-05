using System.Collections;
using System.Collections.Generic;
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
        _vInput = Input.GetAxis("Vertical") * _moveSpeed;
        _hInput = Input.GetAxis("Horizontal") * _rotateSpeed;

        //Setting the mouse input by using the floats to the x and y values times the sensitivity and time
        float mouseX = Input.GetAxis("Mouse X") * _sensX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensY * Time.deltaTime;

        _yRotation += mouseX;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.Rotate(Vector3.up * mouseX);
        
        // Rotating the rigidbody based on the rotation from the vertical and horizontal angles times the mouse input
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(Vector3.left * mouseY));
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(Vector3.up * mouseX));
    }

    private void LateUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(transform.position+transform.forward*_vInput*Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation*angleRot);
    }
}
