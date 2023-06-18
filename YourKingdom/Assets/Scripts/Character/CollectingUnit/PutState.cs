using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.Unit;

namespace Kingdom.StateMachine
{
    public class PutState : IState<CollectingUnit>
    {
        private float _waitingTime;
        private float _currentTime = 0;

        public PutState(float waitingTime)
        {
            _waitingTime = waitingTime;
        }

        public void InitState(CollectingUnit controller) { }

        public void UpdateState(CollectingUnit controller)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > _waitingTime)
            {
                _currentTime = 0;
                controller.AddResource();
                controller.ChangeState(controller.GoToTarget);
            }

        }
    }
}
