using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class WordPanel : MonoBehaviour
{

   
    
    
    
    private void ToggleUI(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
   
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleUI(false);
        }

    }
}
