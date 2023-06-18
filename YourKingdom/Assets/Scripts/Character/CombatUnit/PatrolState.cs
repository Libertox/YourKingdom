using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.Unit;

namespace Kingdom.StateMachine
{
    public class PatrolState : IState<CombatUnit>
    {
        public void InitState(CombatUnit controller) { }

        public void UpdateState(CombatUnit controller)
        {
            Collider2D collider2D = Physics2D.OverlapCircle(controller.transform.position, controller.CharacterStats.Range * 2, controller.EnemyLayerMask);
            if (collider2D)
            {
                if (collider2D.TryGetComponent(out Enemy enemy))
                    controller.ChangeState(new AttackState(enemy));
            }
        }
    }
}
