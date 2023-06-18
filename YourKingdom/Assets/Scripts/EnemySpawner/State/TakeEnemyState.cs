using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom.StateMachine
{
    public class TakeEnemyState : IState<EnemyShip>
    {
        private float _waitingTime;
        private float _currentTime;
        private TransportEnemyState _transportEnemyState = new TransportEnemyState();

        public void InitState(EnemyShip controller)
        {
            controller.RandomQuantiyEnemyToSpwan();
            _waitingTime = controller.AttackDelay;
            _currentTime = 0.0f;
        }

        public void UpdateState(EnemyShip controller)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > _waitingTime)
                controller.ChangeState(_transportEnemyState);
        }
    }
}
