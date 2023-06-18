using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.BuildingObject;

namespace Kingdom.Unit
{
    public class Miner : CollectingUnit
    {
        [SerializeField] private int _gainStoneAmount;
        private MinerHosue _minerHosue;

        public override void AddResource() => PlayerResources.Instance.AddStoneAmount(_gainStoneAmount);

        public void SetMinerHouse(MinerHosue minerHosue) => _minerHosue = minerHosue;

        public override Transform ChooseTarget()
        {
            for (int i = 0; i < _minerHosue.ResourceTargetList.Count; i++)
            {
                if (_minerHosue.ResourceTargetList[i])
                {
                    _chooseTarget = _minerHosue.ResourceTargetList[i];
                    return _minerHosue.ResourceTargetList[i].transform;
                }

            }
            return _spawnPoint;
        }

        public override void DestroySelf()
        {
            base.DestroySelf();
            PlayerResources.Instance.AddMinerAmount(-1);
        }
    }
}
