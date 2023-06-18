using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.Unit;

namespace Kingdom.StateMachine
{

    public class BackState : IState<CollectingUnit>
    {
        private Transform _target;

        public BackState(Transform target)
        {
            _target = target;
        }

        public void InitState(CollectingUnit controller) => controller.SetDestination(_target.transform.position);

        public void UpdateState(CollectingUnit controller)
        {
            if (controller.TargetAchieved())
                controller.ChangeState(controller.PutResource);
        }
    }
}
