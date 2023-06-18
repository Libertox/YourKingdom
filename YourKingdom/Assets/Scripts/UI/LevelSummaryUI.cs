using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Kingdom.MapHandler;

namespace Kingdom.UI
{
    public class LevelSummaryUI : MonoBehaviour
    {
        private const string _victoryText = "VICTORY";
        private const string _loseText = "GAME OVER";
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _survivingWavesText;
        [SerializeField] private TextMeshProUGUI _defeatedOpponentsText;
        [SerializeField] private TextMeshProUGUI _lostBuildingsText;
        [SerializeField] private TextMeshProUGUI _lostUnitText;

        [SerializeField] private Button _restartGameButton;
        [SerializeField] private Button _backToMenuButton;


        private void Start()
        {
            GameManager.Instance.OnGameOverStateChanged += GameManager_OnGameOverStateChanged;
            GameManager.Instance.OnCompleteStateChanged += GameManager_OnCompleteStateChanged;

            _restartGameButton.onClick.AddListener(() => 
            {
                BuildingSystem.Instance.SetSelectedMode(TypeOfBuildingModification.None);
                Loader.LoadScene(Loader.Scence.Game);
             });
            _backToMenuButton.onClick.AddListener(() => 
            {
                BuildingSystem.Instance.SetSelectedMode(TypeOfBuildingModification.None);
                Loader.LoadScene(Loader.Scence.MainMenu);
            });

            gameObject.SetActive(false);
        }

        private void GameManager_OnCompleteStateChanged(object sender, System.EventArgs e)
        {
            _titleText.SetText(_victoryText);
            UpdateStatisticText();
        }

        private void GameManager_OnGameOverStateChanged(object sender, System.EventArgs e)
        {
            _titleText.SetText(_loseText);
            UpdateStatisticText();
        }

        private void UpdateStatisticText()
        {
            Time.timeScale = 0f;

            _survivingWavesText.SetText($"Surviving Waves : {EnemySpawnerManager.Instance.WaveNumber}");
            _defeatedOpponentsText.SetText($"Defeated Opponents : {GameManager.Instance.GameStatistic.DefeatedEnemy}");
            _lostUnitText.SetText($"Lost Units : {GameManager.Instance.GameStatistic.LoseUnit}");
            _lostBuildingsText.SetText($"Lost Buildings : {GameManager.Instance.GameStatistic.LoseBuilding}");

            gameObject.SetActive(true);
        }
    }
}
