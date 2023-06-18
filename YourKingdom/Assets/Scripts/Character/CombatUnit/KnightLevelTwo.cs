using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.StateMachine;

namespace Kingdom.Unit
{
    public class KnightLevelTwo : CombatUnit
    {
        public override void Init()
        {
            base.Init();
            ChangeState(new IdleState(transform.position));
            PlayerResources.Instance.AddWarriorLevelTwoAmount(1);
        }

        public override void DestroySelf()
        {
            base.DestroySelf();
            PlayerResources.Instance.AddWarriorLevelTwoAmount(1);
        }
    }
}
