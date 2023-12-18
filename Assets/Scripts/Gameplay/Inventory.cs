using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Compendium _compendium;
    public static Action _showCompendium = delegate {  };


    private void OnEnable()
    {
        _showCompendium += OnShowCompendium;
    }

    private void OnDisable()
    {
        _showCompendium -= OnShowCompendium;
    }

    private void OnShowCompendium()
    {
        Debug.Log("Compendium Works!");
        _compendium.gameObject.SetActive(!_compendium.gameObject.activeInHierarchy);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
