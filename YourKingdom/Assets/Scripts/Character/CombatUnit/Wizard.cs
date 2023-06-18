using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.StateMachine;

namespace Kingdom.Unit
{
    public class Wizard : CombatUnit
    {
        public override void Init()
        {
            base.Init();
            ChangeState(new IdleState(transform.position));
            PlayerResources.Instance.AddWizardAmount(1);
        }

        public override void DestroySelf()
        {
            base.DestroySelf();
            PlayerResources.Instance.AddWizardAmount(-1);
        }
    }
}
