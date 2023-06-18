using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.Unit;

namespace Kingdom.BuildingObject
{
    public class MinerHosue : Building
    {
        [SerializeField] private Miner _minerPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private GameObject _smoke;

        private List<Miner> _spawnedMinersList = new List<Miner>();
        private CalculateDistanceToResource _calculatingDistance = new CalculateDistanceToResource();

        public List<Resource> ResourceTargetList { get; private set; }
        public override void Built()
        {
            base.Built();
            ResourceTargetList = _calculatingDistance.CalculateDistance(_buildingSystem.ObjectManager.StoneList, this);
            SpawnMiner();
            _smoke.SetActive(true);
        }

        private void SpawnMiner()
        {
            Miner miner = Instantiate(_minerPrefab, _spawnPoint.position, Quaternion.identity);

            _spawnedMinersList.Add(miner);

            miner.SetMinerHouse(this);
            miner.SetSpawnPointTransform(_spawnPoint);
            miner.Init();

            PlayerResources.Instance.AddMinerAmount(1);
        }

        public override void LevelUp()
        {
            if (CheckBuildingIsNotMaxLevel())
            {
                base.LevelUp();
                SpawnMiner();
            }
        }

        public override void DestroySelf()
        {
            base.DestroySelf();
            foreach (Miner miner in _spawnedMinersList)
            {
                if (miner != null)
                    miner.DestroySelf();
            }
        }

    }
}
