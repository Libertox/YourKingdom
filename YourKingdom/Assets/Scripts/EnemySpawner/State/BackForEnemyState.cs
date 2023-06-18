using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom.StateMachine
{
    public class BackForEnemyState : IState<EnemyShip>
    {
        private float _speed = 4.0f;

        public void InitState(EnemyShip controller)
        {
            Vector3 eulers = new Vector3(0, 180, 0);
            controller.transform.Rotate(eulers);
        }

        public void UpdateState(EnemyShip controller)
        {
            controller.transform.position = Vector3.MoveTowards(controller.transform.position, controller.BasePosition.position, Time.deltaTime * _speed);
            if (controller.transform.position == controller.BasePosition.position)
                controller.Disactive();
        }
    }
}
