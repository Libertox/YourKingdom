using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{
    public class EnemySpawnerManager : MonoBehaviour
    {
        public static EnemySpawnerManager Instance { get; private set; }

        public event EventHandler OnAttackStateChagned;
        public event EventHandler OnPreparingStateChanged;
        private enum State
        {
            Preparing,
            Attack,
        }

        [SerializeField] private int _minQuantityEnemy;
        [SerializeField] private float _maxWaveCooldown;
        [SerializeField] private int _numberOfWavesToWin;

        private State _currentState;
        private int _numberOfEnemyOnField;

        public float WaitingTimeBetweenState { get; private set; }
        public int WaveNumber { get; private set; }
        public int MinQuantityEnemy => _minQuantityEnemy;
        public int MaxQuantityEnemy => WaveNumber/3 + _minQuantityEnemy;

        private void Awake()
        {
            if (!Instance)
                Instance = this;

            _currentState = State.Preparing;
            WaveNumber = 0;
            WaitingTimeBetweenState = _maxWaveCooldown;
        }
        private void Update()
        {
            switch (_currentState)
            {
                case State.Preparing:
                    if (_numberOfEnemyOnField <= 0)
                    {
                        WaitingTimeBetweenState -= Time.deltaTime;
                        if (WaitingTimeBetweenState < 0)
                        {
                            WaveNumber++;
                            WaitingTimeBetweenState = _maxWaveCooldown;
                            _currentState = State.Attack;
                            OnAttackStateChagned?.Invoke(this, EventArgs.Empty);
                            if (WaveNumber >= _numberOfWavesToWin)
                                GameManager.Instance.SetGameState(GameManager.GameState.Complete);
                        }
                    }
                    break;
                case State.Attack:
                     if (_numberOfEnemyOnField <= 0)
                     {
                         OnPreparingStateChanged?.Invoke(this, EventArgs.Empty);
                          _currentState = State.Preparing;
                        _numberOfEnemyOnField = 0;
                     }
                     break;
            }
        }

        public bool IsWaitState() => _currentState == State.Preparing;

        public void AddNumberOfEnemyOnField(int value) => _numberOfEnemyOnField += value;
       

    }
}
