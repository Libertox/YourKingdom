using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.MapHandler;

namespace Kingdom
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private BoundsInt bounds;

        public void DestroySelf()
        {
            TilemapHandler.SetTilesBlock(bounds, BuildingSystem.Instance.TileBase[TileType.White], BuildingSystem.Instance.FieldTilemap);
            Destroy(gameObject);
        }

        public void SetBoundsPosition(Vector3Int position) => bounds.position = position;
    }
}
