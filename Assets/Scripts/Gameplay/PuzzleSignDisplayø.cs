using System;
using System.Linq;
using UnityEngine;
using TMPro;

namespace Gameplay
{
    public class PuzzleSignDisplayø : MonoBehaviour
    {
        [SerializeField] private CompendiumEntry _compendiumEntry;
        [SerializeField] private string _currentPuzzleString;
        [SerializeField] private TextMeshPro _tmPro;
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            _tmPro ??= GetComponent<TextMeshPro>();
            string new_string = string.Empty;
            
            if (_compendiumEntry!=null)
            {
                _currentPuzzleString = _compendiumEntry.EntryName;
                for (int i = 0; i < _currentPuzzleString.Length; i++)
                {
                    char current = _currentPuzzleString[i];
                    
                    if (Alphabet.Letters.Contains(_currentPuzzleString[i]))
                    {
                        new_string += '_';
                    }
                    else
                    {
                        new_string += ' ';
                    }
                }

                _currentPuzzleString = new_string;
                _tmPro.text = _currentPuzzleString;

            }
        }
#endif
        
        
    }
}