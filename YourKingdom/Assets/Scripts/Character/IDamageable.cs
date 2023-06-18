using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{
    public interface IDamageable
    {
        public void GetDamage(int damage);

        public void CheckHealthStatus();

        public Vector3 GetPosition();

        public void DestroySelf();

        public bool IsExist();

    }
}
