using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{

    [CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings/CameraSettings", order = 0)]
    public class CameraSettings : ScriptableObject
    {
        [Header("Zoom Options")]
        [SerializeField] private float _zoomLerpSpeed;
        [SerializeField] private float _zoomSpeed;
        [SerializeField] private float _maxZoom;
        [SerializeField] private float _minZoom;

        public float ZoomLerpSpeed => _zoomLerpSpeed;
        public float ZoomSpeed => _zoomSpeed;
        public float MaxZoom => _maxZoom;
        public float MinZoom => _minZoom;

        [Header("Move Options")]
        [SerializeField] private float _borderThickness;
        [SerializeField] private float _moveSpeed;

        public float BorderThickness => _borderThickness;
        public float MoveSpeed => _moveSpeed;

    }
}
