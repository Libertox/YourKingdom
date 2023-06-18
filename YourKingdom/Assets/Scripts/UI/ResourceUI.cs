using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kingdom.UI
{
    public class ResourceUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _woodAmount;
        [SerializeField] private TextMeshProUGUI _stoneAmount;
        [SerializeField] private TextMeshProUGUI _grainAmount;
        [SerializeField] private TextMeshProUGUI _minerAmount;
        [SerializeField] private TextMeshProUGUI _lumbermanAmount;
        [SerializeField] private TextMeshProUGUI _knightAmount;
        [SerializeField] private TextMeshProUGUI _knightLevelTwoAmount;
        [SerializeField] private TextMeshProUGUI _archerAmount;
        [SerializeField] private TextMeshProUGUI _wizardAmount;


        private void Start()
        {
            PlayerResources playerResources = PlayerResources.Instance;

            playerResources.OnArcherAmountChanged += PlayerResources_OnArcherAmountChanged;
            playerResources.OnLumbermanAmountChanged += PlayerResources_OnLumbermanAmountChanged;
            playerResources.OnMinerAmountChanged += PlayerResources_OnMinerAmountChanged;
            playerResources.OnWarriorAmountChanged += PlayerResources_OnWarriorAmountChanged;
            playerResources.OnWarriorLevelTwoAmountChanged += PlayerResources_OnWarriorLevelTwoAmountChanged;
            playerResources.OnWizardAmountChanged += PlayerResources_OnWizardAmountChanged;

            playerResources.OnOwnedResourceAmountChanged += PlayerResources_OnOwnedResourceAmountChanged;
            playerResources.OnDemandResourceShowed += PlayerResources_OnDemandResourceShowed;

            SetMaterialsText(playerResources.OwnedResources);

        }

        private void PlayerResources_OnDemandResourceShowed(object sender, PlayerResources.OnOwnedResourceAmountChangedEventArgs e)
        {
            PlayerResources playerResources = sender as PlayerResources;

            SetMaterialsText(e.materials);

            _woodAmount.color = playerResources.OwnedResources.wood >= e.materials.wood ? Color.green : Color.red;
            _stoneAmount.color = playerResources.OwnedResources.stone >= e.materials.stone ? Color.green : Color.red;
            _grainAmount.color = playerResources.OwnedResources.grain >= e.materials.grain ? Color.green : Color.red;


        }

        private void PlayerResources_OnOwnedResourceAmountChanged(object sender, PlayerResources.OnOwnedResourceAmountChangedEventArgs e)
        {
            SetMaterialsText(e.materials);

            _woodAmount.color = Color.black;
            _stoneAmount.color = Color.black;
            _grainAmount.color = Color.black;
        }

        private void SetMaterialsText(Materials material) 
        {
            _woodAmount.SetText($"{material.wood}");
            _stoneAmount.SetText($"{material.stone}");
            _grainAmount.SetText($"{material.grain}");
        }

        private void PlayerResources_OnWizardAmountChanged(object sender, PlayerResources.OnResourcesChangedEventArgs e)
        {
            _wizardAmount.SetText($"{e.resourceChaged}");
        }

        private void PlayerResources_OnWarriorLevelTwoAmountChanged(object sender, PlayerResources.OnResourcesChangedEventArgs e)
        {
            _knightLevelTwoAmount.SetText($"{e.resourceChaged}");
        }

        private void PlayerResources_OnWarriorAmountChanged(object sender, PlayerResources.OnResourcesChangedEventArgs e)
        {
            _knightAmount.SetText($"{e.resourceChaged}");
        }

        private void PlayerResources_OnMinerAmountChanged(object sender, PlayerResources.OnResourcesChangedEventArgs e)
        {
            _minerAmount.SetText($"{e.resourceChaged}");
        }

        private void PlayerResources_OnLumbermanAmountChanged(object sender, PlayerResources.OnResourcesChangedEventArgs e)
        {
            _lumbermanAmount.SetText($"{e.resourceChaged}");
        }

        private void PlayerResources_OnArcherAmountChanged(object sender, PlayerResources.OnResourcesChangedEventArgs e)
        {
            _archerAmount.SetText($"{e.resourceChaged}");
        }

    }
}
