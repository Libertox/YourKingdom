using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom.StateMachine
{
    public interface StateMachine<T>
    {
        public abstract void ChangeState(IState<T> newState);
        public abstract void UpdateState();
    }
}
