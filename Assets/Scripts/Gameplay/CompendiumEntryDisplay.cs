using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    [RequireComponent(typeof(RawImage))]
    public class CompendiumEntryDisplay : MonoBehaviour
    {
        [SerializeField] private CompendiumEntry _entry;
        public CompendiumEntry Entry
        {
            set
            {
                if (string.IsNullOrEmpty(value.name))
                    return;
                _entry = value;
            }
        }
    }
}