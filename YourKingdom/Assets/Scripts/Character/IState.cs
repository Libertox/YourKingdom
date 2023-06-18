using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom.StateMachine
{
    public interface IState<T>
    {
        public abstract void InitState(T controller);

        public abstract void UpdateState(T controller);

    }
}
