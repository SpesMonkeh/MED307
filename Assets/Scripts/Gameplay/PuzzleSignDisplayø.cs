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
        [SerializeField] private TextMeshProUGUI _winText;
        
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            _tmPro ??= GetComponent<TextMeshPro>();
            string _newString = string.Empty;
            
            if (_compendiumEntry!=null)
            {
                _currentPuzzleString = _compendiumEntry.EntryName;
                for (int i = 0; i < _currentPuzzleString.Length; i++)
                {
                    var current = _currentPuzzleString[i];
                    
                    if (Alphabet.Letters.Contains(_currentPuzzleString[i]))
                    {
                        _newString += '_';
                    }
                    else
                    {
                        _newString += ' ';
                    }
                }

                _currentPuzzleString = _newString;
                _tmPro.text = _currentPuzzleString;

            }
        }
#endif

        private void YouWin()
        {
            if (_currentPuzzleString == _compendiumEntry.EntryName)
            {
                _winText.gameObject.SetActive(true);
            }
        }
        
        
        
    }
}