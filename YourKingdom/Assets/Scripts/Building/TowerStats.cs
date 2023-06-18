using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom.BuildingObject
{

    [CreateAssetMenu(fileName = "TowerStats", menuName = "BuildingStats/TowerStats", order = 1)]
    public class TowerStats : BuildingStats
    {
        [SerializeField] private float _range;
        [SerializeField] private int _power;
        [SerializeField] private float _shootDelay;

        public float Range => _range;
        public int Power => _power;
        public float ShootDelay => _shootDelay;
    }
}
