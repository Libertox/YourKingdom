using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.Unit;

namespace Kingdom
{
    public class TowerBullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _raycastDistance;
        [SerializeField] private LayerMask _layerMask;

        public Transform TargetTransform { get; private set; }
        private int _damage;

        private void Update()
        {
            if (!TargetTransform)
                gameObject.SetActive(false);
            else
            {
                HitEnemy();
                MoveTowardsTarget();
            }

        }
        private void MoveTowardsTarget()
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetTransform.transform.position, _speed * Time.deltaTime);
            transform.up = TargetTransform.position - transform.position;
        }

        private void HitEnemy()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, TargetTransform.position - transform.position, _raycastDistance, _layerMask);
            if (hit.collider)
            {
                if (hit.collider.TryGetComponent(out Enemy enemy))
                {
                    enemy.GetDamage(_damage);
                    gameObject.SetActive(false);
                }
            }
        }

        public void SetTargetTransform(Transform target) => TargetTransform = target;

        public void SetDamage(int damage) => _damage = damage;

    }
}
