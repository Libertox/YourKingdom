using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.MapHandler;

namespace Kingdom.Unit
{
    public class ControlCombatUnit : MonoBehaviour
    {
        private Camera _gameCamera;
        private Vector3 _startPosition;
        private Vector3 _currentPosition;
        private List<CombatUnit> _selectedUnit;

        [SerializeField] private Transform _indicator;
        [SerializeField] private LayerMask _layerMask;

        private void Awake()
        {
            _gameCamera = Camera.main;
            _selectedUnit = new List<CombatUnit>();
        }

        private void Update()
        {
            if (CanChooseUnit())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _startPosition = GetWorldPositionOfMouse();
                    _indicator.gameObject.SetActive(true);
                }
                if (Input.GetMouseButton(0))
                    DrawSelectionRectangle();
                if (Input.GetMouseButtonUp(0))
                    SelectedUnit();
                if (Input.GetMouseButtonDown(1))
                    GiveUnitCommand();
            }
        }

        private bool CanChooseUnit() => BuildingSystem.Instance.IsNoneMode() && GameManager.Instance.IsNoneState();

        Vector3 GetWorldPositionOfMouse() => _gameCamera.ScreenToWorldPoint(Input.mousePosition);

        private void DrawSelectionRectangle()
        {
            _currentPosition = GetWorldPositionOfMouse();
            Vector3 lowerLeftBoundry = new Vector3(Mathf.Min(_currentPosition.x, _startPosition.x),
                                       Mathf.Min(_currentPosition.y, _startPosition.y));
            Vector3 upperRightBoundry = new Vector3(Mathf.Max(_currentPosition.x, _startPosition.x),
                                        Mathf.Max(_currentPosition.y, _startPosition.y));

            _indicator.position = lowerLeftBoundry;
            _indicator.localScale = upperRightBoundry - lowerLeftBoundry;
        }

        private void SelectedUnit()
        {
            Collider2D[] collider2Ds = Physics2D.OverlapAreaAll(_startPosition, GetWorldPositionOfMouse(), _layerMask);
            foreach (CombatUnit unit in _selectedUnit)
            {
                if (unit)
                {
                    unit.SetVisibleSelectedIndicator(false);
                    unit.HealthBar.Hide();
                }
            }
            _selectedUnit.Clear();
            foreach (Collider2D collider2D in collider2Ds)
            {
                if (collider2D.TryGetComponent(out CombatUnit unit))
                {
                    _selectedUnit.Add(unit);
                    unit.SetVisibleSelectedIndicator(true);
                    unit.HealthBar.Show();
                }
            }
            _indicator.gameObject.SetActive(false);
        }

        private void GiveUnitCommand()
        {
            Vector3 movePosition = GetWorldPositionOfMouse();
            Collider2D collider2D = Physics2D.OverlapPoint(movePosition);
            if (collider2D)
            {
                if (collider2D.TryGetComponent(out Enemy enemy))
                {
                    foreach (CombatUnit unit in _selectedUnit)
                    {
                        if (unit)
                            unit.TurnAttackState(enemy);
                    }
                }
            }
            else
            {
                foreach (CombatUnit unit in _selectedUnit)
                {
                    if (unit)
                        unit.TurnIdleState(movePosition);
                }

            }
        }
    }
}
