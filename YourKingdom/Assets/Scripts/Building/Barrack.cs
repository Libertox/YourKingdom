using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.Unit;

namespace Kingdom.BuildingObject
{

    public class Barrack : Building
    {
        public static event EventHandler OnBarrackSelected;


        [SerializeField] private Vector3 _unitSpawnOffset;
        private float _buyingDuration;
        private float _buyingUnitProgress;

        public bool IsBuyingUnit { get; private set; }


        public override void Update()
        {
            base.Update();
            if (IsBuyingUnit)
            {
                _buyingUnitProgress += Time.deltaTime;
                _progressBar.ChangeFileOfBar(_buyingUnitProgress / _buyingDuration);
            }
        }

        new public static void ResetStaticData() => OnBarrackSelected = null;

        public override void Selected()
        {
            if (IsBuilt())
            {
                base.Selected();
                OnBarrackSelected?.Invoke(this, EventArgs.Empty);
            }
        }

        public IEnumerator BuyingUnit(CombatUnitStats unitStats)
        {
            IsBuyingUnit = true;
            _buyingDuration = unitStats.DurationOfBuy;
            _progressBar.Show();

            yield return new WaitForSeconds(unitStats.DurationOfBuy);

            Character character = Instantiate(unitStats.CharacterPrefab, transform.position + _unitSpawnOffset, Quaternion.identity);
            character.Init();

            PlayerResources.Instance.SubstractMaterials(unitStats.BuyResources);
            AudioManager.Instance.PlayUnitRecruitmentSound();

            IsBuyingUnit = false;
            _buyingUnitProgress = 0;
            _progressBar.Hide();
        }
    }
}
