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
    
    public static Action<CompendiumEntry> _thePlayerPickup = delegate {  };
    

    /*
        * - Lav en metode: AddEntry(CompendiumEntry entry)
        * - I AddEntry:
        * - - Tjek, om entry er C.Action action eller C.Sign sign
        * - - Tjek, om action eller sign er opbevaret i tilhørende Dictionary
        * - - Hvis ikke: Tilføj entry som Key og bool == false som Value => dictionary.TryAdd(key: entry, value: false)
        * - - Hvis ja og dictionary[entry] == true:
        * - -      new GameObject(entry.EntryName, typeof(CompendiumEntryDisplay));
        * - -      osv.
        * 
        */

    
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

    private void AddEntry(CompendiumEntry entry)
    {
        Debug.Log("AddEntryWorks");
        if (entry is CompendiumAction action)
        {
            if (!_actionDict.ContainsKey(action))
            {
                _actionDict.TryAdd(action, false);

            }
            else if (_actionDict.ContainsKey(action) && _actionDict[action] == true)
            {
                var newEntryDisplay = new GameObject(entry.EntryName, typeof(CompendiumEntryDisplay));

            }
            
            
        }
        else if (entry is CompendiumSign sign)
        {
            if (!_signDict.ContainsKey(sign))
            {
                _signDict.TryAdd(sign, false);
            }
            else if (_signDict.ContainsKey(sign) && _signDict[sign] == true)
            {
                
                var newEntryDisplay = new GameObject(entry.EntryName, typeof(CompendiumEntryDisplay));

            }
            
        }
    }

    private void OnEnable()
    {
        _thePlayerPickup += AddEntry;
    }

    private void OnDisable()
    {
        _thePlayerPickup -= AddEntry;
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
