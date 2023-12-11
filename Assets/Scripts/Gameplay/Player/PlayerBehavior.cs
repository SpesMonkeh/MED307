using UnityEngine;

namespace P307.Runtime.Gameplay.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerBehavior : MonoBehaviour
    {
        [Header("Required Components")]
        [SerializeField] Rigidbody _rigidBody;
        [SerializeField] PlayerHead _head;
        [SerializeField] GameObject tracks;
        
        [Space(5), Header("Movement Settings")]
        [SerializeField] float _moveSpeed;
        [SerializeField] float _rotateSpeed;
    
        // Floats containing input values
        float _vInput;
        float _hInput;
    
        // Floats containing rotations values
        float _xRotation;
        float _yRotation;
    
        // Floats containing move sensitivity
        [SerializeField] float _sensX;
        [SerializeField] private float _sensY;
    
        void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _head = GetComponentInChildren<PlayerHead>();
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
            //transform.Rotate(Vector3.up * mouseX);
            
            Vector2 headRotation = new Vector2(mouseY, mouseX);
            _head.Rotate(headRotation);

            // Rotating the rigidbody based on the rotation from the vertical and horizontal angles times the mouse input
            //_rigidBody.MoveRotation(_rigidBody.rotation * Quaternion.Euler(Vector3.left * mouseY));
            //_rigidBody.MoveRotation(_rigidBody.rotation * Quaternion.Euler(Vector3.up * mouseX));
        }

        void FixedUpdate()
        {
            RotateBody();
        }
        
        void RotateBody()
        {
            Transform tf = transform;
            Vector3 rotation = Vector3.up * _hInput;
            Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
            _rigidBody.MovePosition(tf.position + tf.forward * (_vInput * Time.fixedDeltaTime));
            _rigidBody.MoveRotation(_rigidBody.rotation * angleRot);
        }
    }
}
