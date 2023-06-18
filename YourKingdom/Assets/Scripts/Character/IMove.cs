using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom.Unit
{

    public interface IMove
    {
        public void SetDestination(Vector3 target);
        public bool TargetAchieved();
    }
}
