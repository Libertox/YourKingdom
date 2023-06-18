using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom.StateMachine
{
    public class TransportEnemyState : IState<EnemyShip>
    {
        private Vector3 _destination;
        private float _speed;
        private float _balanceFactor = 8f;
        private SpawnEnemyState _spawnEnemyState = new SpawnEnemyState();

        public void InitState(EnemyShip controller)
        {
            _destination = controller.RandomPointOnLine();
            _speed = _balanceFactor / controller.QuantityEnemyToSpawn;
            Vector3 eulers = new Vector3(0, -180, 0);
            controller.transform.Rotate(eulers);
        }

        public void UpdateState(EnemyShip controller)
        {
            controller.transform.position = Vector3.MoveTowards(controller.transform.position, _destination, Time.deltaTime * _speed);
            if (controller.transform.position == _destination)
                controller.ChangeState(_spawnEnemyState);
        }
    }
}
