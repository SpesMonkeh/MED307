using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay;
using Unity.VisualScripting;
using UnityEngine;

public class Compendium : MonoBehaviour
{
    private List<CompendiumEntry> entryNames = new();
    private Dictionary<CompendiumAction, bool> _actionDict = new();
    private Dictionary<CompendiumSign, bool> _signDict = new();
    
    public static Action _playerPickUp = delegate {  };

    
    private void Awake()
    {
        entryNames = Resources.LoadAll<CompendiumEntry>("Compendium Entry").ToList();
        Debug.Log(entryNames.Count);
        foreach (var entry in entryNames)
        {
            var a = new GameObject(entry.EntryName, typeof(CompendiumEntryDisplay));
            var b = a.GetComponent<CompendiumEntryDisplay>();
            b.Entry = entry;
            a.gameObject.transform.SetParent(this.gameObject.transform);
            if (entry is CompendiumAction action)
            {
                _actionDict.TryAdd(action, false);
                Debug.Log($"ActionDict {_actionDict.Count}");
            }
            else if (entry is CompendiumSign sign)
            {
                _signDict.TryAdd(sign, false);
                Debug.Log($"SignDict {_signDict.Count}");
            }
            
        }
    }


    private void OnEnable()
    {
        _playerPickUp += CheckCompendium;
        _playerPickUp += UpdateCompendium;
    }

    private void OnDisable()
    {
        _playerPickUp -= CheckCompendium;
        _playerPickUp -= UpdateCompendium;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void CheckCompendium()
    {
        if (GameObject.FindGameObjectWithTag("Compendium").activeInHierarchy)
        {
            foreach (var entry in entryNames)
            {
                
                if (entry is CompendiumAction action)
                {
                    if (_actionDict[action] == true)
                    {
                        return;
                    }
                    _actionDict[action] = false;
                    
                }
                
                if (entry is CompendiumSign sign)
                {
                    if (_signDict[sign] == true)
                    {
                        return;
                    }
                    _signDict[sign] = false; 
                    
                }
            }
        }
        
    }
    
    private void UpdateCompendium()
    {
        var entryNumber = _signDict;
        if (GameObject.FindGameObjectWithTag("A").activeInHierarchy)
        {
            
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
