using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.StateMachine;
using Kingdom.Unit;

namespace Kingdom
{
    public class EnemyShip : MonoBehaviour, StateMachine<EnemyShip>
    {
        [SerializeField] private Enemy _enemyPrefab;

        [SerializeField] private Transform[] _spawnPosition;
        [SerializeField] private Transform _basePosition;
        [SerializeField] private float _attackDelay;

        //straight line coefficients
        private float a;
        private float b;

        private IState<EnemyShip> _currentState;
        private TakeEnemyState _takeEnemyState;

        public int QuantityEnemyToSpawn { get; private set; }
        public Transform BasePosition => _basePosition;
        public float AttackDelay => _attackDelay + QuantityEnemyToSpawn;

        private void Start()
        {
            a = (_spawnPosition[1].position.y - _spawnPosition[0].position.y) / (_spawnPosition[1].position.x - _spawnPosition[0].position.x);
            b = _spawnPosition[0].position.y - a * _spawnPosition[0].position.x;
            _takeEnemyState = new TakeEnemyState();
            EnemySpawnerManager.Instance.OnAttackStateChagned += EnemySpawnerManager_OnAttackStateChagned;
            Disactive();
        }

        private void EnemySpawnerManager_OnAttackStateChagned(object sender, System.EventArgs e) => Active();

        private void Update() => UpdateState();

        public void SpawnEnemy()
        {
            for (int i = 1; i <= QuantityEnemyToSpawn; i++)
            {
                Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
                enemy.Init();
            }
        }

        public Vector3 RandomPointOnLine()
        {
            float positionX = Random.Range(_spawnPosition[0].position.x, _spawnPosition[1].position.x);
            float positionY = a * positionX + b;
            return new Vector3(positionX, positionY, 0);
        }

        public void RandomQuantiyEnemyToSpwan()
        {
            QuantityEnemyToSpawn = Random.Range(EnemySpawnerManager.Instance.MinQuantityEnemy, EnemySpawnerManager.Instance.MaxQuantityEnemy);
            EnemySpawnerManager.Instance.AddNumberOfEnemyOnField(QuantityEnemyToSpawn);
        }

        private void Active()
        {
            gameObject.SetActive(true);
            ChangeState(_takeEnemyState);
        }

        public void Disactive() => gameObject.SetActive(false);

        #region -------State Machine Implementation---------

        public void ChangeState(IState<EnemyShip> newState)
        {
            _currentState = newState;
            _currentState?.InitState(this);
        }

        public void UpdateState() => _currentState?.UpdateState(this);

        #endregion
    }
}