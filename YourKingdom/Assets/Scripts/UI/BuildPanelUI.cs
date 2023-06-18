using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kingdom.BuildingObject;
using Kingdom.MapHandler;

namespace Kingdom.UI
{
    public class BuildPanelUI : MonoBehaviour
    {

        private const string IS_OPEN = "IsOpen";
        private const string IS_CLOSE = "IsClose";

        private Animator _buildPanelUIAnim;

        [SerializeField] private Button _backButton;

        [SerializeField] private InteractableButton _minerHouseButton;
        [SerializeField] private InteractableButton _lumbermanHouseButton;
        [SerializeField] private InteractableButton _millButton;
        [SerializeField] private InteractableButton _barrackButton;
        [SerializeField] private InteractableButton _archerTowerButton;
        [SerializeField] private InteractableButton _mageTowerButton;

        [Space(10)]

        [SerializeField] private BuildingStats _minerHouseStats;
        [SerializeField] private BuildingStats _lumbermanHouseStats;
        [SerializeField] private BuildingStats _millStats;
        [SerializeField] private BuildingStats _barrackStats;
        [SerializeField] private BuildingStats _archerTowerStats;
        [SerializeField] private BuildingStats _mageTowerStats;

        private void Awake() => _buildPanelUIAnim = GetComponent<Animator>();

        private void Start()
        {
            BuildingSystem.Instance.OnStateBuiled += BuildingSystem_OnStateBuiled;

            _backButton.onClick.AddListener(() =>
            {
                Close();
                BuildingSystem.Instance.SetSelectedMode(TypeOfBuildingModification.None);
                AudioManager.Instance.PlayButtonSound();
            });

            _minerHouseButton.SetDemandResourcesAndAction(_minerHouseStats.BuildResources, () =>
                BuildingSystem.Instance.InitializeWithBuilding(_minerHouseStats.BuildingPrefab));

            _lumbermanHouseButton.SetDemandResourcesAndAction(_lumbermanHouseStats.BuildResources, () =>
                BuildingSystem.Instance.InitializeWithBuilding(_lumbermanHouseStats.BuildingPrefab));

            _millButton.SetDemandResourcesAndAction(_millStats.BuildResources, () =>
                BuildingSystem.Instance.InitializeWithBuilding(_millStats.BuildingPrefab));

            _barrackButton.SetDemandResourcesAndAction(_barrackStats.BuildResources, () =>
               BuildingSystem.Instance.InitializeWithBuilding(_barrackStats.BuildingPrefab));

            _archerTowerButton.SetDemandResourcesAndAction(_archerTowerStats.BuildResources, () =>
              BuildingSystem.Instance.InitializeWithBuilding(_archerTowerStats.BuildingPrefab));

            _mageTowerButton.SetDemandResourcesAndAction(_mageTowerStats.BuildResources, () =>
              BuildingSystem.Instance.InitializeWithBuilding(_mageTowerStats.BuildingPrefab));

        }

        private void BuildingSystem_OnStateBuiled(object sender, System.EventArgs e) => Show();
        private void Show()
        {
            _buildPanelUIAnim.SetBool(IS_OPEN, true);
            _buildPanelUIAnim.SetBool(IS_CLOSE, false);
        }
        private void Close()
        {
            _buildPanelUIAnim.SetBool(IS_OPEN, false);
            _buildPanelUIAnim.SetBool(IS_CLOSE, true);
        }
    }
}