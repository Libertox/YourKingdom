using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{
    public class LoadingScence : MonoBehaviour
    {
        [SerializeField] private float _loadTimer;
        private float _waitingTimer;

        private void Start() => Time.timeScale = 1f;

        private void Update()
        {
            _waitingTimer += Time.deltaTime;
            if (_waitingTimer > _loadTimer)
                Loader.LoadTargetScene();
        }
    }
}
