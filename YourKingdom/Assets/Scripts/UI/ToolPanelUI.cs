using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kingdom.MapHandler;

namespace Kingdom.UI
{
    public class ToolPanelUI : MonoBehaviour
    {
        [SerializeField] private Button _buildButton;
        [SerializeField] private Button _removeButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _pauseMenu;

        private void Start()
        {
            _buildButton.onClick.AddListener(() =>
            {
                BuildingSystem.Instance.SetSelectedMode(TypeOfBuildingModification.Bulid);
                AudioManager.Instance.PlayButtonSound();
            });

            _removeButton.onClick.AddListener(() =>
            {
                BuildingSystem.Instance.SetSelectedMode(TypeOfBuildingModification.Remove);
                AudioManager.Instance.PlayButtonSound();
            });

            _settingsButton.onClick.AddListener(() =>
            {
                GameManager.Instance.SetGameState(GameManager.GameState.Settings);
                AudioManager.Instance.PlayButtonSound();
            });

            _pauseMenu.onClick.AddListener(() =>
            {
                GameManager.Instance.SetGameState(GameManager.GameState.Pause);
                AudioManager.Instance.PlayButtonSound();
            });

        }
    }
}
