using System;
using System.Collections;
using System.Collections.Generic;
using P307.Runtime.Inputs;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static Action<GameMode> DoChangeGameMode;
    public static event Action<GameMode> GameModeWasChanged;
    public static GameMode CurrentGameMode=GameMode.None;

    private void OnEnable()
    {
        DoChangeGameMode += TryChangeGameMode;
    }

    private void OnDisable()
    {
        DoChangeGameMode -= TryChangeGameMode;
    }
    
    public static void TryChangeGameMode(GameMode mode)
    {
        if (CurrentGameMode!=mode)
        {
            CurrentGameMode = mode;
            GameModeWasChanged?.Invoke(CurrentGameMode);
            Debug.Log(CurrentGameMode);
        }
        else
        {
            return;
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject.FindGameObjectWithTag("Panel").SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Inventory._showCompendium?.Invoke();
            
        }
    }
    
    
    
}
