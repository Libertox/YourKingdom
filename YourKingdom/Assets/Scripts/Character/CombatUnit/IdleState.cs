using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.Unit;

namespace Kingdom.StateMachine
{
    public class IdleState : IState<CombatUnit>
    {
        private Vector3 _positionToMove;

        public IdleState(Vector3 positionToMove) => _positionToMove = positionToMove;

        public void InitState(CombatUnit controller) => controller.SetDestination(_positionToMove);

        public void UpdateState(CombatUnit controller)
        {
            if (controller.TargetAchieved())
                controller.ChangeState(new PatrolState());
        }
    }
}