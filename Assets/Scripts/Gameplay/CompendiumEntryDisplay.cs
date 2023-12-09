using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    [RequireComponent(typeof(RawImage))]
    public class CompendiumEntryDisplay : MonoBehaviour
    {
        [SerializeField] private CompendiumEntry _entry;
        [SerializeField] private RawImage _image;
        public CompendiumEntry Entry
        {
            set
            {
                if (string.IsNullOrEmpty(value.name))
                    return;
                _image ??= GetComponent<RawImage>();
                _image.texture = value.EntryImage;
                _image.enabled = false;
                _entry = value;
            }
        }

        private void Awake()
        {
            _image ??= GetComponent<RawImage>();
        }

        private void OnEnable()
        {
            Compendium._thePlayerPickup += OnPlayerPickup;
        }

        private void OnDisable()
        {
            Compendium._thePlayerPickup -= OnPlayerPickup;
        }

        void OnPlayerPickup(CompendiumEntry entryPickup)
        {
            _image.enabled = entryPickup == _entry;
        }
    }
}