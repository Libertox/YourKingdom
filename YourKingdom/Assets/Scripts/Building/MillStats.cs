using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom.BuildingObject
{
    [CreateAssetMenu(fileName = "MillStats", menuName = "BuildingStats/MillStats", order = 2)]
    public class MillStats : BuildingStats
    {
        [SerializeField] private float _cooldown;
        [SerializeField] private int _grainAdded;

        public float Cooldown => _cooldown;
        public int GrainAdded => _grainAdded;
    }
}