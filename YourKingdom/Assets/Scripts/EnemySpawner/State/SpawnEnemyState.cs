using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Kingdom.StateMachine
{
    public class SpawnEnemyState : IState<EnemyShip>
    {
        private float _waitingTime;
        private float _currentTime;
        private float _balanceFactor = 1.5f;
        private BackForEnemyState _backForEnemyState = new BackForEnemyState();

        public void InitState(EnemyShip controller)
        {
            _waitingTime = controller.QuantityEnemyToSpawn * _balanceFactor;
            _currentTime = 0.0f;
        }

        public void UpdateState(EnemyShip controller)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > _waitingTime)
            {
                controller.SpawnEnemy();
                controller.ChangeState(_backForEnemyState);
            }

        }
    }
}
