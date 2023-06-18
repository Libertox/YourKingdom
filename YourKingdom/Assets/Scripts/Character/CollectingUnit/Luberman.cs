using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.BuildingObject;

namespace Kingdom.Unit
{

    public class Luberman : CollectingUnit
    {
        [SerializeField] private int _gainWoodAmount;
        private LumbermanHouse _lumbermanHouse;

        public override void AddResource() => PlayerResources.Instance.AddWoodAmount(_gainWoodAmount);

        public void SetLumbermanHouse(LumbermanHouse lumbermanHouse) => _lumbermanHouse = lumbermanHouse;

        public override Transform ChooseTarget()
        {
            for (int i = 0; i < _lumbermanHouse.ResourceTargetList.Count; i++)
            {
                if (_lumbermanHouse.ResourceTargetList[i])
                {
                    _chooseTarget = _lumbermanHouse.ResourceTargetList[i];
                    return _lumbermanHouse.ResourceTargetList[i].transform;
                }

            }
            return _spawnPoint;
        }

        public override void DestroySelf()
        {
            base.DestroySelf();
            PlayerResources.Instance.AddLubermanAmount(-1);
        }
    }
}
