using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom.Unit
{

    [CreateAssetMenu(fileName = "BasicStats", menuName = "CharacterStats/BasicStats", order = 0)]
    public class CharacterStats : ScriptableObject
    {
        [SerializeField] private Character _characterPrefab;
        [SerializeField] int _maxHealth;
        [SerializeField] private float _range;
        [SerializeField] float _movmentSpeed;

        public Character CharacterPrefab => _characterPrefab;
        public int MaxHealth => _maxHealth;
        public float Range => _range;
        public float MovementSpeed => _movmentSpeed;
    }
}
