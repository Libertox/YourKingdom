using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kingdom.Unit;
using Kingdom.BuildingObject;

namespace Kingdom.UI
{
    public class UnitBuyUI : MonoBehaviour
    {
        private const string IS_OPEN = "IsOpen";
        private const string IS_CLOSE = "IsClose";

        private Barrack _chooseBuilding;
        private Animator _unitUIAnim;

        [SerializeField] private InteractableButton _knightButton;
        [SerializeField] private InteractableButton _knightLevelTwoButton;
        [SerializeField] private InteractableButton _archerButton;
        [SerializeField] private InteractableButton _mageButton;

        [SerializeField] private CombatUnitStats _knightPrefab;
        [SerializeField] private CombatUnitStats _knightLevelTwoPrefab;
        [SerializeField] private CombatUnitStats _archerPrefab;
        [SerializeField] private CombatUnitStats _magePrefab;


        private void Awake() => _unitUIAnim = GetComponent<Animator>();

        private void Start()
        {
            Barrack.OnBarrackSelected += Barrack_OnBarrackChoosed;
            Building.OnUnselected += Building_OnUnselected;

            _knightButton.SetDemandResourcesAndAction(_knightPrefab.BuyResources, () => InitializeWithUnit(_knightPrefab));
            _knightLevelTwoButton.SetDemandResourcesAndAction(_knightLevelTwoPrefab.BuyResources, () => InitializeWithUnit(_knightLevelTwoPrefab));
            _archerButton.SetDemandResourcesAndAction(_archerPrefab.BuyResources, () => InitializeWithUnit(_archerPrefab));
            _mageButton.SetDemandResourcesAndAction(_magePrefab.BuyResources, () => InitializeWithUnit(_magePrefab));
        }

        private void Building_OnUnselected(object sender, System.EventArgs e)
        {
            if (sender as Building == _chooseBuilding)
            {
                _chooseBuilding = null;
                _unitUIAnim.SetBool(IS_OPEN, false);
                _unitUIAnim.SetBool(IS_CLOSE, true);
            }
        }

        private void Barrack_OnBarrackChoosed(object sender, System.EventArgs e)
        {
            _chooseBuilding = sender as Barrack;
            ActiveAccessibleUnitButton();
            _unitUIAnim.SetBool(IS_OPEN, true);
            _unitUIAnim.SetBool(IS_CLOSE, false);
        }

        private void ActiveAccessibleUnitButton()
        {
            switch (_chooseBuilding.Level)
            {
                case 0:
                    _knightLevelTwoButton.Hide();
                    _mageButton.Hide();
                    break;
                case 1:
                    _knightLevelTwoButton.Show();
                    _mageButton.Hide();
                    break;
                case 2:
                    _knightLevelTwoButton.Show();
                    _mageButton.Show();
                    break;
            }
        }

        private void InitializeWithUnit(CombatUnitStats unit)
        {
            if (!_chooseBuilding) return;

            if (PlayerResources.Instance.CheckEnoughResources(unit.BuyResources) && !_chooseBuilding.IsBuyingUnit)
                StartCoroutine(_chooseBuilding.BuyingUnit(unit));
        }

    }
}
