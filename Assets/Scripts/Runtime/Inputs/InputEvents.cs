using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace P307.Runtime.Inputs
{
    public class InputEvents : MonoBehaviour, PlayerInputs.IInGameActions
    {
        private PlayerInput _playerInput;
        private PlayerInputs _inputs;
        public static Action<Vector2, GameMode> HasMovementInput=delegate {  };
        public static GameMode CurrentGameMode = GameMode.Moving;

        private void OnEnable()
        {
            _inputs ??= new PlayerInputs();
            _inputs.InGame.SetCallbacks(this);
            _inputs.InGame.Enable();
        }

        private void OnDisable()
        {
            _inputs.InGame.RemoveCallbacks(this);
            _inputs.InGame.Disable();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            HasMovementInput?.Invoke(context.ReadValue<Vector2>(), CurrentGameMode);
        }

        public void OnWriting(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                
            }
        }
    }
    public enum GameMode
    {
        Typing,
        Moving,
        Gesturing,
        None,
        
    }

}