using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.MapHandler;

namespace Kingdom
{
    public class CursorController : MonoBehaviour
    {
        [SerializeField] private CursorIconSO cursorIconSO;

        private Dictionary<TypeOfBuildingModification, Texture2D> _icons;

        public void Awake()
        {
            _icons = new Dictionary<TypeOfBuildingModification, Texture2D>
        {
            { TypeOfBuildingModification.None, cursorIconSO.BaseIcon },
            { TypeOfBuildingModification.Bulid, cursorIconSO.BuildIcon },
            { TypeOfBuildingModification.Remove, cursorIconSO.RemoveIcon },
        };
        }

        private void Start()
        {
            Cursor.SetCursor(_icons[TypeOfBuildingModification.None], Vector2.zero, CursorMode.Auto);
            BuildingSystem.Instance.OnStateBuiled += BuildingSystem_OnStateBuiled;
            BuildingSystem.Instance.OnStateRemoved += BuildingSystem_OnStateRemoved;
            BuildingSystem.Instance.OnStateNoned += BuildingSystem_OnStateNoned;

        }

        private void BuildingSystem_OnStateNoned(object sender, System.EventArgs e)
        {
            Cursor.SetCursor(_icons[TypeOfBuildingModification.None], Vector2.zero, CursorMode.Auto);
        }

        private void BuildingSystem_OnStateRemoved(object sender, System.EventArgs e)
        {
            Cursor.SetCursor(_icons[TypeOfBuildingModification.Remove], Vector2.zero, CursorMode.Auto);
        }

        private void BuildingSystem_OnStateBuiled(object sender, System.EventArgs e)
        {
            Cursor.SetCursor(_icons[TypeOfBuildingModification.Bulid], Vector2.zero, CursorMode.Auto);
        }

    }
}


