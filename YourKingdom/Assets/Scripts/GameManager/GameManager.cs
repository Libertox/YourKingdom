using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{
    public class GameManager : MonoBehaviour
    {
        public enum GameState
        {
            None,
            Pause,
            Settings,
            GameOver,
            Complete
        }
        public static GameManager Instance { get; private set; }

        private GameState _currentState;

        public event EventHandler OnSettingStateChanged;
        public event EventHandler OnPasueStateChanged;
        public event EventHandler OnGameOverStateChanged;
        public event EventHandler OnCompleteStateChanged;

        public GameStatistic GameStatistic { get; private set; }

        private void Awake()
        {
            if (!Instance)
                Instance = this;

            GameStatistic = new GameStatistic();
        }

        private void Start()
        {
            GameInput.Instance.OnPauseMenuChanged += GameInput_OnPauseMenuChanged;
            GameInput.Instance.OnSettingsChanged += GameInput_OnSettingsChanged;
            AudioManager.Instance.PlayGameplayMusic();
            _currentState = GameState.None;
        }

        private void GameInput_OnSettingsChanged(object sender, EventArgs e)
        {
            if (IsNoneState() || IsSettingsState())
                SetGameState(GameState.Settings);
        }

        private void GameInput_OnPauseMenuChanged(object sender, EventArgs e)
        {
            if (IsNoneState() || IsPauseState())
                SetGameState(GameState.Pause);
        }

        public void SetGameState(GameState gameState)
        {
            _currentState = gameState;
            switch (gameState)
            {
                case GameState.Pause:
                    OnPasueStateChanged?.Invoke(this, EventArgs.Empty);
                    break;
                case GameState.Settings:
                    OnSettingStateChanged?.Invoke(this, EventArgs.Empty);
                    break;
                case GameState.GameOver:
                    OnGameOverStateChanged?.Invoke(this, EventArgs.Empty);
                    break;
                case GameState.Complete:
                    OnCompleteStateChanged?.Invoke(this, EventArgs.Empty);
                    break;
            }

        }

        public bool IsNoneState() => _currentState == GameState.None;

        public bool IsPauseState() => _currentState == GameState.Pause;

        public bool IsSettingsState() => _currentState == GameState.Settings;

        public bool IsGameOverState() => _currentState == GameState.GameOver;
    }
}
