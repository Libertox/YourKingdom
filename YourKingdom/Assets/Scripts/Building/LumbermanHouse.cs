using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.Unit;

namespace Kingdom.BuildingObject
{
    public class LumbermanHouse : Building
    {
        [SerializeField] private Luberman _lumbermanPrefab;
        [SerializeField] private Transform _spawnPoint;

        private List<Luberman> _spawnedLubermanList = new List<Luberman>();
        private CalculateDistanceToResource _calculatingDistance = new CalculateDistanceToResource();
        public List<Resource> ResourceTargetList { get; private set; }

        public override void Built()
        {
            base.Built();
            ResourceTargetList = _calculatingDistance.CalculateDistance(_buildingSystem.ObjectManager.TreeList, this);
            SpawnLumberman();
        }

        private void SpawnLumberman()
        {
            Luberman luberman = Instantiate(_lumbermanPrefab, _spawnPoint.position, Quaternion.identity);

            _spawnedLubermanList.Add(luberman);

            luberman.SetLumbermanHouse(this);
            luberman.SetSpawnPointTransform(_spawnPoint);
            luberman.Init();
            PlayerResources.Instance.AddLubermanAmount(1);
        }

        public override void LevelUp()
        {
            if (CheckBuildingIsNotMaxLevel())
            {
                base.LevelUp();
                SpawnLumberman();
            }
        }

        public override void DestroySelf()
        {
            base.DestroySelf();
            foreach (Luberman luberman in _spawnedLubermanList)
            {
                if (luberman != null)
                    luberman.DestroySelf();
            }
        }
    }
}
