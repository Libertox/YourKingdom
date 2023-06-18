using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.MapHandler;

namespace Kingdom.BuildingObject
{
    public class BuildingSelection : MonoBehaviour
    {
        private Camera _gameCamera;
        private Building _selectBuilding;
        private Building _previousSelectBuilding;

        [SerializeField] private LayerMask _buildingLayer;

        private void Awake() => _gameCamera = Camera.main;

        void Update()
        {
            if (!GameManager.Instance.IsNoneState()) return;

            if (Input.GetMouseButton(0))
                InteractWithBuilding();

            if (Input.GetMouseButtonUp(0) && BuildingSystem.Instance.IsBuiltMode())
                _selectBuilding = null;
        }

        private void InteractWithBuilding()
        {
            Vector2 mousePosition = GetWorldPositionOfMouse();
            Collider2D colider = Physics2D.OverlapPoint(mousePosition, _buildingLayer);
            if (colider)
            {
                _previousSelectBuilding = _selectBuilding;
                if (colider.TryGetComponent(out _selectBuilding))
                {
                    if (BuildingSystem.Instance.IsRemoveMode())
                        _selectBuilding.Sell();
                    else if (BuildingSystem.Instance.IsBuiltMode())
                    {
                        if (_previousSelectBuilding && !_selectBuilding.IsPlanned())
                            _selectBuilding = _previousSelectBuilding;

                        _selectBuilding.MoveBuilding();
                    }

                    else if (BuildingSystem.Instance.IsNoneMode())
                    {
                        if (_previousSelectBuilding != null)
                            _previousSelectBuilding.UnSelected();


                        _selectBuilding.Selected();
                    }

                }
            }

            if (BuildingSystem.Instance.IsBuiltMode())
                _selectBuilding?.MoveBuilding();
        }

        Vector3 GetWorldPositionOfMouse() => _gameCamera.ScreenToWorldPoint(Input.mousePosition);

    }
}
