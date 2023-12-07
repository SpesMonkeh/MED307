using UnityEngine;

namespace Gameplay
{
    public abstract class CompendiumEntry : ScriptableObject
    {
        [SerializeField] protected string _entryName;
        [SerializeField] protected Texture _entryImage;
        [SerializeField] protected string _niceifiedName;
        public string EntryName => _entryName;
        public Texture EntryImage => _entryImage;

    }
}