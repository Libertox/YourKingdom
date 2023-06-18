using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Kingdom.Unit
{
    public class Character : MonoBehaviour, IMove, IDamageable
    {
        private NavMeshAgent agent;
        protected float _health;

        [SerializeField] protected Bar _healthBar;
        [SerializeField] private CharacterStats _characterStats;

        public Bar HealthBar => _healthBar;
        public CharacterStats CharacterStats => _characterStats;

        public virtual void Init()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.stoppingDistance = _characterStats.Range;
            agent.speed = _characterStats.MovementSpeed;
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            _health = _characterStats.MaxHealth;
        }

        #region ------- IDamageable Implementation ---------

        public Vector3 GetPosition() => transform.position;
        public void GetDamage(int damage)
        {
            _health -= damage;
            float currentHealth = (_health / _characterStats.MaxHealth);
            _healthBar.ChangeFileOfBar(currentHealth);

            CheckHealthStatus();
        }
        public virtual void DestroySelf() => Destroy(gameObject);
        public virtual void CheckHealthStatus()
        {
            if (_health > 0)
            {
                if (_health < _characterStats.MaxHealth)
                {
                    _healthBar.Show();
                }
            }
            else
            {
                GameManager.Instance.GameStatistic.AddLoseUnit();
                DestroySelf();
            }
        }
        public bool IsExist() => (this != null);

        #endregion


        #region ------- IMove Implementation ---------
        public void SetDestination(Vector3 target) => agent.SetDestination(target);

        public bool TargetAchieved()
        {
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion
    }
}
