using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Kingdom
{

    public class CameraController : MonoBehaviour
    {
        private Camera _gameCamera;

        [SerializeField] private CameraSettings _settings;
        [SerializeField] private Tilemap _boundry;

        private float _zoom;

        private Vector3 _bottomLeftLimit;
        private Vector3 _topRightLimit;

        private float _halfHeight;
        private float _halfWidth;

        private float _screenHeight;
        private float _screenWidth;

        private void Start()
        {
            _gameCamera = GetComponent<Camera>();
            _zoom = _gameCamera.orthographicSize;

            _halfHeight = _gameCamera.orthographicSize;
            _halfWidth = _halfHeight * _gameCamera.aspect;

            _bottomLeftLimit = _boundry.localBounds.min + new Vector3(_halfWidth, _halfHeight, 0f);
            _topRightLimit = _boundry.localBounds.max + new Vector3(-_halfWidth, -_halfHeight, 0f);



            transform.position = new Vector3(
                (_boundry.localBounds.min.x + _boundry.localBounds.max.x) * 0.5f,
                (_boundry.localBounds.min.y + _boundry.localBounds.max.y) * 0.5f,
                -10);
        }

        private void Update()
        {
            ZoomCamera();
            MoveCamera();
        }

        private void ZoomCamera()
        {
            float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
            _zoom -= scrollDelta * _settings.ZoomSpeed;
            _zoom = Mathf.Clamp(_zoom, _settings.MinZoom, _settings.MaxZoom);
            _gameCamera.orthographicSize = Mathf.Lerp(_gameCamera.orthographicSize, _zoom, Time.deltaTime * _settings.ZoomLerpSpeed);

        }

        private void MoveCamera()
        {
            Vector2 mouseDirection = GameInput.Instance.GetMouseMovement();

            _screenHeight = Screen.height;
            _screenWidth = Screen.width;

            if (Input.mousePosition.x >= _screenWidth - _settings.BorderThickness)
                mouseDirection = Vector2.right;
            if (Input.mousePosition.x <= _settings.BorderThickness)
                mouseDirection = Vector2.left;
            if (Input.mousePosition.y >= _screenHeight - _settings.BorderThickness)
                mouseDirection = Vector2.up;
            if (Input.mousePosition.y <= _settings.BorderThickness)
                mouseDirection = Vector2.down;

            transform.Translate(mouseDirection * (Time.deltaTime * _settings.MoveSpeed));

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _bottomLeftLimit.x, _topRightLimit.x),
                       Mathf.Clamp(transform.position.y, _bottomLeftLimit.y, _topRightLimit.y), transform.position.z);
        }
    }
}
