using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBehavior : MonoBehaviour
{

    /*
     * 1.
     * 
     * Opret eventuelt et MonoBehaviour script, f.eks. WordPanel, smæk det på et GameObject og lav det til en prefab, som
     * placeres i Assets/Prefabs/Resources/UI
     * Hent prefab'en i Awake() vha. Resources.Load<WordPanel>( NAVN PÅ PREFAB FIL ) og opbevar i en variabel, WordPanel wordPanelPrefab, maybe.
     *
     * Hver gang en ny CompendiumEntry samles op => newEntry = Instantiate(wordPanelPrefab, parent: transform)
     * Giv newEntry det opsamlede CompendiumEntry ScriptableObject, så newEntry kan læse den Texture, som opbevares i SO'en
     * tilføj newEntry til en liste, wordPanels, måske?
     *
     * WordPanel kan indeholde en metode, som tænder og slukker for det UI komponenter eller child-GOs.
     */
    
    [SerializeField] private List<WordPanel> _wordPanels;

    [SerializeField] private WordPanel _wordPanelPrefab;

    [SerializeField] private CompendiumEntry _theCompendiumEntry;
    private Dictionary<CompendiumEntry, WordPanel> _wordPanelsEntries;
    
    [SerializeField] private RawImage _letterTexture;

    [SerializeField] private GameObject _ThePanel;

    private DoorBehavior DoorBehavior;

    
    private void Awake()
    {
        _wordPanelPrefab = Resources.Load<WordPanel>("UI/Word Panel");
        DoorBehavior = GameObject.Find("Door").GetComponent<DoorBehavior>();
    }

    private void CollectCard(CompendiumEntry entry)
    {

        SetCompendiumEntry(entry);
        WordPanel newEntry = Instantiate(_wordPanelPrefab,GameObject.Find("Canvas").transform);

    }


    private void SetCompendiumEntry(CompendiumEntry entry)
    {
        
        _letterTexture.texture = entry.EntryImage;

    }
    
    private void TurnOnThePanel()
    {
        _ThePanel.SetActive(true);
        Debug.Log("Finds the panel");
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.TryGetComponent(out PlayerBehavior playerObj) is false)
                      return;
        Compendium._thePlayerPickup?.Invoke(_theCompendiumEntry);
        TurnOnThePanel();
        CollectCard(_theCompendiumEntry);
        DoorBehavior.UpdateSignCount(1);
        gameObject.SetActive(false);

    }
    

   
    
}
