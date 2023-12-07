using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject.FindGameObjectWithTag("Panel").SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Inventory._showCompendium?.Invoke();
            
        }
    }
}
