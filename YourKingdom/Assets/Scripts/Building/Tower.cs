using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.MapHandler;
using Kingdom.Unit;

namespace Kingdom.BuildingObject
{
    public class Tower : Building
    {

        [SerializeField] private List<TowerBullet> _bullets;
        [SerializeField] private Transform _spawnPointForBullets;
        [SerializeField] private GameObject _rangeIndicator;
        [SerializeField] private LayerMask _enemyLayerMask;

        private bool _isShoot;
        private TowerStats towerStats;

        public override void Update()
        {
            base.Update();
            if (CanShoot())
            {
                Collider2D collider2D = Physics2D.OverlapCircle(transform.position, towerStats.Range, _enemyLayerMask);
                if (collider2D)
                {
                    if (collider2D.TryGetComponent(out Enemy enemy))
                        StartCoroutine(Shoot(enemy));
                }
            }
        }
        private bool CanShoot() => (!_isShoot && IsBuilt());

        public override void Init(BuildingSystem buildingSystem)
        {
            base.Init(buildingSystem);
            towerStats = (TowerStats)BuildingStats;
        }

        public override void Built()
        {
            base.Built();
            UpdateRangeIncicator();
        }
        public override void LevelUp()
        {
            base.LevelUp();
            towerStats = (TowerStats)BuildingStats;
            UpdateRangeIncicator();
        }

        private void UpdateRangeIncicator() => _rangeIndicator.transform.localScale = new Vector3(towerStats.Range * 2, towerStats.Range * 2, 1);

        private IEnumerator Shoot(Enemy target)
        {
            TowerBullet bullet = SpawnTowerBullet();
            if (bullet)
            {
                bullet.gameObject.SetActive(true);
                bullet.transform.position = _spawnPointForBullets.transform.position;
                bullet.SetTargetTransform(target.transform);
                bullet.SetDamage(towerStats.Power);
                _isShoot = true;
            }
            yield return new WaitForSeconds(towerStats.ShootDelay);
            _isShoot = false;
        }

        public override void Selected()
        {
            base.Selected();
            if (IsBuilt())
                _rangeIndicator.SetActive(true);
        }

        public override void HideUIElement()
        {
            base.HideUIElement();
            _rangeIndicator.SetActive(false);
        }

        private TowerBullet SpawnTowerBullet()
        {
            for (int i = 0; i < _bullets.Count; i++)
            {
                if (!_bullets[i].gameObject.activeInHierarchy)
                    return _bullets[i];
            }
            return null;
        }


    }
}
