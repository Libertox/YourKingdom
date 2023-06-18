using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Kingdom.MapHandler
{

    [CreateAssetMenu()]
    public class TileBaseSO : ScriptableObject
    {

        [SerializeField] private TileBase _redTileBase;
        [SerializeField] private TileBase _greenTileBase;
        [SerializeField] private TileBase _whiteTileBase;

        public TileBase RedTileBase => _redTileBase;
        public TileBase GreenTileBase => _greenTileBase;
        public TileBase WhiteTileBase => _whiteTileBase;

    }
}