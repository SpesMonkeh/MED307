using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private Transform _playerTransform;
    
    private void Start()
    {
        _playerTransform= GameObject.Find("Player").transform;
    }

   

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _playerTransform.position;
        transform.rotation = _playerTransform.rotation;
    }
}
