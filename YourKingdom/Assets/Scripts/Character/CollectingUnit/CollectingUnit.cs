using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.StateMachine;

namespace Kingdom.Unit
{
    public class CollectingUnit : Character, StateMachine<CollectingUnit>
    {
        protected Resource _chooseTarget;
        protected Transform _spawnPoint;

        private IState<CollectingUnit> _currentState;
        [SerializeField] private float _waitingTime = 5f;

        public WalkState GoToTarget { get; private set; }
        public GatherState GahterResource { get; private set; }
        public BackState BackToHome { get; private set; }
        public PutState PutResource { get; private set; }


        private void Update() => UpdateState();

        public override void Init()
        {
            base.Init();

            ChooseTarget();

            GoToTarget = new WalkState(_chooseTarget.transform);
            GahterResource = new GatherState(_waitingTime);
            BackToHome = new BackState(_spawnPoint);
            PutResource = new PutState(_waitingTime);

            ChangeState(GoToTarget);
        }
        public virtual Transform ChooseTarget() => _spawnPoint;

        public Transform GetChooseTarget()
        {
            if (_chooseTarget) return _chooseTarget.transform;
            else return null;
        }


        public void DestroyChooseTarget()
        {
            if (_chooseTarget)
                _chooseTarget.DestroySelf();
        }

        public void SetSpawnPointTransform(Transform spawPoint) => _spawnPoint = spawPoint;

        public virtual void AddResource() { }

        #region -------State Machine Implementation---------
        public void ChangeState(IState<CollectingUnit> newState)
        {
            _currentState = newState;
            _currentState?.InitState(this);
        }

        public void UpdateState() => _currentState?.UpdateState(this);
        #endregion

    }
}