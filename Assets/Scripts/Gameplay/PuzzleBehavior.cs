using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class PuzzleBehavior : MonoBehaviour
{
    [SerializeField] private Text _codeText;
    [SerializeField] private string _rightText;
    [SerializeField] private PuzzleEntry _puzzleEntry;
    


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
    

    private void IfCodeIsCorrect()
    {
        if (_codeText.ToString()==_puzzleEntry.RightAnswer)
        {
            Debug.Log("Correct!");
        }
    }

    private void Update()
    {
        
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
            Debug.Log(obj);
        }
        
    }
}
