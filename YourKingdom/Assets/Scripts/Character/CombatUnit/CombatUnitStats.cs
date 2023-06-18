using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom.Unit
{

    [CreateAssetMenu(fileName = "CombatUnitStats", menuName = "CharacterStats/CombatUnitStats", order = 1)]
    public class CombatUnitStats : CharacterStats
    {

        [SerializeField] private int _damage;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private int _durationOfBuy;
        [SerializeField] private Materials _buyResources;

        public int Damage => _damage;
        public float AttackCooldown => _attackCooldown;
        public int DurationOfBuy => _durationOfBuy;
        public Materials BuyResources => _buyResources;
    }
}