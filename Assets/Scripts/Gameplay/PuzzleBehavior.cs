using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class PuzzleBehavior : MonoBehaviour
{
    [SerializeField] private TextMeshPro _tmPro;
    [SerializeField] private string _currentPuzzleString;
    [SerializeField] private string _rightText;
    [SerializeField] private CompendiumEntry _compendiumEntry;
    private int currentIndex;
   
   


    private void Awake()
    {
        
        
    }


    private void OnWriting()
    {
        
        if (Keyboard.current.anyKey.isPressed)
        {
            var pressedKey = Keyboard.current.allKeys.FirstOrDefault(key => key.isPressed);
            if (pressedKey!=null)
            {
                Debug.Log(Keyboard.current);
            }
            
        }
    }
    
   
    
    
    private void OnEnable()
    {
        Keyboard.current.onTextInput += GetKeyInput;
    }

    private void OnDisable()
    {
        
        Keyboard.current.onTextInput -= GetKeyInput;
    }

    
    private void GetKeyInput(char obj)
    {
        
        if (Alphabet.Letters.Contains(obj))
        {
            UpdateText(obj);
            
        }
        
    }
    
    
    private void UpdateText(char obj)
    {
        if (currentIndex < _compendiumEntry.EntryName.Length)
        {
            if (char.IsWhiteSpace(_compendiumEntry.EntryName[currentIndex]))
            {
                currentIndex++;
            }

            var currentChar = _compendiumEntry.EntryName[currentIndex];

           
            if (char.ToLower(currentChar) != char.ToLower(obj))
            {
                return;
            }

            var charArray = _tmPro.text.ToCharArray();

            
            charArray[currentIndex] = char.IsUpper(currentChar) ? char.ToUpper(obj) : char.ToLower(obj);

            _tmPro.text = new string(charArray);

            currentIndex++;
        }
    }
    
}

