using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.Unit;

namespace Kingdom.StateMachine
{
    public class WalkState : IState<CollectingUnit>
    {
        private Transform _target;

        public WalkState(Transform target)
        {
            _target = target;
        }

        public void InitState(CollectingUnit controller)
        {
            if (!_target)
                _target = controller.ChooseTarget();

            controller.SetDestination(_target.transform.position);
        }

        public void UpdateState(CollectingUnit controller)
        {
            if (!_target)
            {
                _target = controller.ChooseTarget();
                controller.SetDestination(_target.transform.position);
            }

            if (controller.TargetAchieved())
                controller.ChangeState(controller.GahterResource);
        }
    }
}
