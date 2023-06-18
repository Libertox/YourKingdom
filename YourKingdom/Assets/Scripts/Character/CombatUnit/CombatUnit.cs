using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.StateMachine;

namespace Kingdom.Unit
{
    public class CombatUnit : Character, StateMachine<CombatUnit>
    {
        private IState<CombatUnit> currentState;
        [SerializeField] private GameObject _selectedIndicator;
        [SerializeField] private LayerMask _enemyLayerMask;

        public LayerMask EnemyLayerMask => _enemyLayerMask;

        private void Update() => UpdateState();

        public void SetVisibleSelectedIndicator(bool active) => _selectedIndicator.SetActive(active);

        public void TurnAttackState(Enemy target) => ChangeState(new AttackState(target));

        public void TurnIdleState(Vector3 target) => ChangeState(new IdleState(target));

        public void Attack(Enemy enemyToAttack) => enemyToAttack.GetDamage(((CombatUnitStats)CharacterStats).Damage);


        #region -------State Machine Implementation---------
        public void ChangeState(IState<CombatUnit> newState)
        {
            currentState = newState;
            currentState?.InitState(this);
        }

        public void UpdateState() => currentState?.UpdateState(this);

        #endregion
    }
}
