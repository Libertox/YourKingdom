using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.MapHandler;
using Kingdom.BuildingObject;

namespace Kingdom.Unit
{
    public class Enemy : Character
    {
        [SerializeField] private float _radiusDetection;
        [SerializeField] private LayerMask _layerMask;

        private float timeBetweenAttack;
        private IDamageable target;

        public override void Init()
        {
            base.Init();
            SetDestination(BuildingSystem.Instance.ObjectManager.GetCastle().GetPosition());
        }

        private void Update()
        {

            if (target == null)
            {
                FindTarget();

                if (target == null && BuildingSystem.Instance.ObjectManager.GetCastle() != null)
                    SetDestination(BuildingSystem.Instance.ObjectManager.GetCastle().GetPosition());
            }
            else
            {
                if (target.IsExist())
                {
                    SetDestination(target.GetPosition());
                    if (TargetAchieved())
                        AttackTarget();
                }
                else
                    target = null;
            }
        }

        private void FindTarget()
        {
            Collider2D collider2D = Physics2D.OverlapCircle(transform.position, _radiusDetection, _layerMask);
            if (collider2D)
            {
                collider2D.TryGetComponent(out target);
                if (target is Building)
                {
                    Building building = target as Building;
                    if (!building.IsBuilt())
                        target = null;
                }
            }
        }

        private void AttackTarget()
        {
            timeBetweenAttack += Time.deltaTime;
            if (target.IsExist() && timeBetweenAttack > ((CombatUnitStats)CharacterStats).AttackCooldown)
            {
                target.GetDamage(((CombatUnitStats)CharacterStats).Damage);
                if (target == null)
                    SetDestination(BuildingSystem.Instance.ObjectManager.GetCastle().GetPosition());

                timeBetweenAttack = 0;
            }
        }

        public override void CheckHealthStatus()
        {
            if (_health > 0)
            {
                if (_health < CharacterStats.MaxHealth)
                    _healthBar.Show();
            }
            else
            {
                GameManager.Instance.GameStatistic.AddDefeatedEnemy();
                EnemySpawnerManager.Instance.AddNumberOfEnemyOnField(-1);
                DestroySelf();
            }

        }

    }
}
