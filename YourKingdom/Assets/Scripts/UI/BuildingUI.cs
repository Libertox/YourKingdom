using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kingdom.BuildingObject;

namespace Kingdom.UI
{
    public class BuildingUI : MonoBehaviour
    {
        private const string MOVE_LEFT = "MoveLeft";
        private const string MOVE_RIGHT = "MoveRight";

        [SerializeField] private Image _buildingImage;

        [SerializeField] private Button _closeButton;
        [SerializeField] private InteractableButton _upgradeButton;
        [SerializeField] private InteractableButton _repairButton;
        [SerializeField] private InteractableButton _sellButton;

        private Building _chooseBuilding;
        private Animator _buildingUIAnim;

        private void Awake() => _buildingUIAnim = GetComponent<Animator>();

        private void Start()
        {
            Building.OnSelected += Building_OnSelected;
            Building.OnUnselected += Building_OnUnselected;

            _closeButton.onClick.AddListener(() =>
            {
                _chooseBuilding.UnSelected();
                AudioManager.Instance.PlayButtonSound();
            });

            _upgradeButton.SetActionDelegate(() => _chooseBuilding.Upgrade());
            _repairButton.SetActionDelegate(() => _chooseBuilding.Repair());
            _sellButton.SetActionDelegate(() => _chooseBuilding.Sell());

        }

        private void Building_OnUnselected(object sender, System.EventArgs e)
        {
            if (sender as Building == _chooseBuilding)
            {
                _buildingUIAnim.SetBool(MOVE_LEFT, false);
                _buildingUIAnim.SetBool(MOVE_RIGHT, true);
            }
        }

        private void Building_OnSelected(object sender, System.EventArgs e)
        {
            _chooseBuilding = sender as Building;
            _buildingUIAnim.SetBool(MOVE_LEFT, true);
            _buildingUIAnim.SetBool(MOVE_RIGHT, false);
            UpdateBuildingStats();
        }

        private void UpdateBuildingStats()
        {
            _buildingImage.sprite = _chooseBuilding.BuildingStats.Texture;
            _upgradeButton.SetDemandResources(_chooseBuilding.BuildingStats.UpgradeResources);
            _repairButton.SetDemandResources(_chooseBuilding.BuildingStats.RepaireResources);
            _sellButton.SetDemandResources(_chooseBuilding.BuildingStats.SellResources);
        }
    }
}
