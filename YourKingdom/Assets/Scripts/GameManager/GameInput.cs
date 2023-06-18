using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Kingdom
{
    public class GameInput : MonoBehaviour
    {
        public static GameInput Instance { get; private set; }

        private PlayerInputActions PlayerInputActions;

        public event EventHandler OnBuilted;
        public event EventHandler OnCancelBuilt;
        public event EventHandler OnPauseMenuChanged;
        public event EventHandler OnSettingsChanged;

        private void Awake()
        {
            if (!Instance)
                Instance = this;

            PlayerInputActions = new PlayerInputActions();

            PlayerInputActions.Player.Enable();
            PlayerInputActions.Mouse.Enable();

            PlayerInputActions.Player.Built.performed += Built_performed;
            PlayerInputActions.Player.CancelBuilt.performed += CancelBuilt_performed;
            PlayerInputActions.Player.PauseMenu.performed += PauseMenu_performed;
            PlayerInputActions.Player.SettingsMenu.performed += SettingsMenu_performed;

        }

        private void OnDestroy()
        {
            PlayerInputActions.Player.Built.performed -= Built_performed;
            PlayerInputActions.Player.CancelBuilt.performed -= CancelBuilt_performed;
            PlayerInputActions.Player.PauseMenu.performed -= PauseMenu_performed;
            PlayerInputActions.Player.SettingsMenu.performed -= SettingsMenu_performed;

            PlayerInputActions.Dispose();
        }

        private void PauseMenu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnPauseMenuChanged?.Invoke(this, EventArgs.Empty);
        }

        private void SettingsMenu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnSettingsChanged?.Invoke(this, EventArgs.Empty);
        }

        private void CancelBuilt_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnCancelBuilt?.Invoke(this, EventArgs.Empty);
        }

        private void Built_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnBuilted?.Invoke(this, EventArgs.Empty);
        }

        public Vector2 GetMouseMovement()
        {
            Vector2 direction = PlayerInputActions.Mouse.Move.ReadValue<Vector2>();
            direction = direction.normalized;
            return direction;
        }

    }
}


