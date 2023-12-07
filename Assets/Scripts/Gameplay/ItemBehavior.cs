using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{

    [SerializeField] private GameObject[] _wordPanels;
    
    

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(transform.gameObject);
            if (CompareTag("A"))
            {
                _wordPanels[0].SetActive(true);
                Compendium._playerPickUp?.Invoke();
            }
            else if(CompareTag("B"))
            {
                _wordPanels[1].SetActive(true);
                Compendium._playerPickUp?.Invoke();
            }
            else if (CompareTag("D"))
            {
                _wordPanels[2].SetActive(true);
                Compendium._playerPickUp?.Invoke();
            }
            
            Debug.Log("Item Collected");
            
        }
    }
}
