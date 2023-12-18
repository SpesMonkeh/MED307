using System;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Gameplay
{
    public class PuzzleSignDisplayø : MonoBehaviour
    {
        [SerializeField] private CompendiumEntry _compendiumEntry;
        [SerializeField] private string _currentPuzzleString;
        [SerializeField] private TextMeshPro _tmPro;
        [SerializeField] private TextMeshProUGUI _winText;
        [SerializeField] private RawImage _videoOutput;
        
        public static Action _playerWritesCorrectly;



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

        private void Awake()
        {
            _videoOutput.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _playerWritesCorrectly += YouWin;
        }

        private void OnDisable()
        {
            _playerWritesCorrectly -= YouWin;
        }

        private void YouWin()
        {
            if (_tmPro.text == _compendiumEntry.EntryName)
            {
                
                _winText.gameObject.SetActive(true);
                _videoOutput.gameObject.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            
           
        }

        private void Update()
        {
            _playerWritesCorrectly?.Invoke();
        }
        
        
        
        
    }
}