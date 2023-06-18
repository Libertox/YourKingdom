using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.Unit;

namespace Kingdom.StateMachine
{
    public class AttackState : IState<CombatUnit>
    {
        private Enemy _target;
        private float time = 0;

        public AttackState(Enemy target) => _target = target;

        public void InitState(CombatUnit controller) { }

        public void UpdateState(CombatUnit controller)
        {
            if (!_target)
                controller.ChangeState(new IdleState(controller.transform.position));
            else
            {
                controller.SetDestination(_target.transform.position);
                if (controller.TargetAchieved())
                {
                    time += Time.deltaTime;
                    if (time > ((CombatUnitStats)controller.CharacterStats).AttackCooldown)
                    {
                        controller.Attack(_target);
                        time = 0;
                    }

                }
            }


        }


    }
}
