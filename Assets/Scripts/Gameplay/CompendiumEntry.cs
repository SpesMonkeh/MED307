using UnityEngine;

namespace Gameplay
{
    public abstract class CompendiumEntry : ScriptableObject
    {
        [SerializeField] protected string _entryName;
        
        /*
         * Et script, som skal vise _entryimage vha. Raw Image component. Se lige ItemBehaviour.cs kommentarerne først:
         *
         *		[RequireComponent(typeof(RawImage))]
         *      public class CompendiumEntryDisplay : MonoBehaviour
         *      {
         *          [SerializeField] private CompendiumEntry _entry;
         *			[SerializeField] private RawImage _image;
         * 
         *          public CompendiumEntry Entry
         *          {
         *              set
         *              {
         *                  if (string.IsNullOrEmpty(value.name))
         *                      return;
         *					_image ??= GetComponent<RawImage>();			<-- ??= betyder: Hvis venstre side (_image) er NULL, sæt venstre side 
         *					_image.texture = value.EntryImage;					lig med højre side (GetComponent<RawImage>)
         *					_image.enabled = false;
         *                  _entry = value;
         *              }
         *          }
         *
         *			void Awake()
         *			{
         *				_image ??= GetComponent<RawImage>();
         *			}
         *
         *			void OnEnable()
         *			{
         *				Compendium._playerPickup += OnPlayerPickup;
         *			}
         *
         *			void OnPlayerPickup(CompendiumEntry entryPickup)
         *			{
         *				_image.enabled = entryPickup == _entry;
         *			}
         *      }
         */
        
        [SerializeField] protected Texture _entryImage;
        [SerializeField] protected string _niceifiedName;
        public string EntryName => _entryName;
        public Texture EntryImage => _entryImage;

    }
}