using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.Unit;

namespace Kingdom.StateMachine
{

    public class GatherState : IState<CollectingUnit>
    {
        private float _waitingTime;
        private float _currentTime = 0;

        public GatherState(float waitingTime)
        {
            _waitingTime = waitingTime;
        }

        public void InitState(CollectingUnit controller) { }

        public void UpdateState(CollectingUnit controller)
        {
            if (!controller.GetChooseTarget())
            {
                controller.ChangeState(controller.GoToTarget);
            }
            else
            {
                _currentTime += Time.deltaTime;
                if (_currentTime > _waitingTime)
                {
                    _currentTime = 0;
                    controller.DestroyChooseTarget();
                    controller.ChangeState(controller.BackToHome);
                }
            }

        }
    }
}
