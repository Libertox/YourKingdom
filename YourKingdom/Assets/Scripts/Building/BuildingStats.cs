using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom.BuildingObject
{
    [CreateAssetMenu(fileName = "BuildingStats", menuName = "BuildingStats/BaseStats", order = 0)]
    public class BuildingStats : ScriptableObject
    {
        [SerializeField] private Building _buildingPrefab;
        [SerializeField] private int _maximumHealth;
        [SerializeField] private int _maxBuiltTime;
        [SerializeField] private Sprite _texture;
        [SerializeField] private Materials _upgradeResources;
        [SerializeField] private Materials _repairResources;
        [SerializeField] private Materials _buildResources;
        [SerializeField] private Materials _sellResources;

        public Building BuildingPrefab => _buildingPrefab;
        public int MaximumHealth => _maximumHealth;
        public int MaxBuiltTime => _maxBuiltTime;
        public Sprite Texture => _texture;
        public Materials UpgradeResources => _upgradeResources;
        public Materials RepaireResources => _repairResources;
        public Materials BuildResources => _buildResources;
        public Materials SellResources => _sellResources;
    }
}
