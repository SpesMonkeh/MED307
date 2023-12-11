using P307.Runtime.Gameplay.Player;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] PlayerBehavior player;

    void Start()
    {
	    this.player ??= FindObjectsByType<PlayerBehavior>(FindObjectsInactive.Include, FindObjectsSortMode.None)[0];
    }
}
