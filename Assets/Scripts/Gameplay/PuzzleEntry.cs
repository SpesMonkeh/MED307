using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "Nyt Svar", menuName = "307/PuzzleEntries/NytSvar")]
    public class PuzzleEntry : ScriptableObject
    {
        [SerializeField] protected string _rightAnswer;
        
        public string RightAnswer => _rightAnswer;
        
    }
}