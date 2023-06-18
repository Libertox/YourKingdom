using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Kingdom.BuildingObject;

namespace Kingdom.MapHandler
{
    public class GeneratorMap : MonoBehaviour
    {
        private struct Triangle
        {
            public Vector2 pointA;
            public Vector2 pointB;
            public Vector2 pointC;
            public Triangle(Vector2 A, Vector2 B, Vector2 C)
            {
                pointA = A;
                pointB = B;
                pointC = C;

            }
        }

        [SerializeField] private Tilemap _fieldTilemap;
        [SerializeField] private Tilemap _gameArea;

        [SerializeField] private Resource _treePrefab;
        [SerializeField] private Resource _stonePrefab;
        [SerializeField] private Building _castelPrefab;

        [SerializeField] private int _minBoundrySize;
        [SerializeField] private int _maxBoundrySize;

        [SerializeField] private int _spawnCount;

        private Triangle[] _triangle;
        private BuildingSystem _buildingSystem;

        private void Awake() => _buildingSystem = GetComponent<BuildingSystem>();

        private void Start() => GenerateMap();

        private void GenerateMap()
        {
            _triangle = new Triangle[2];
            float a = (_gameArea.size.y / 2.0f) * _gameArea.cellSize.x;
            float b = (_gameArea.size.x / 2.0f) * (_gameArea.cellSize.y + _gameArea.cellGap.y);
            float xmax = _gameArea.localBounds.max.x;
            float xmin = _gameArea.localBounds.min.x;
            float ymin = _gameArea.localBounds.min.y;
            float ymax = _gameArea.localBounds.max.y;

            _triangle[0] = new Triangle(new Vector2(xmin, (int)(-b + ymax)), new Vector2((int)(a + xmin), ymax), new Vector2((int)(-a + xmax), ymin));
            _triangle[1] = new Triangle(new Vector2(xmax, (int)(b + ymin)), new Vector2((int)(a + xmin), ymax), new Vector2((int)(-a + xmax), ymin));

            SpawnCastle();

            for (int i = 0; i < _spawnCount; i++)
            {
                SpawnTrees();
                SpawnStones();
            }
        }

        private Vector2 RandomWithinTriangle(Triangle t)
        {
            var r1 = Mathf.Sqrt(Random.Range(0f, 1f));
            var r2 = Random.Range(0f, 1f);
            var m1 = 1 - r1;
            var m2 = r1 * (1 - r2);
            var m3 = r2 * r1;

            var p1 = t.pointA;
            var p2 = t.pointB;
            var p3 = t.pointC;
            return (m1 * p1) + (m2 * p2) + (m3 * p3);
        }

        private void SpawnCastle()
        {
            Vector3 castlePosition = new Vector3(
                (_gameArea.localBounds.min.x + _gameArea.localBounds.max.x) / 2,
                (_gameArea.localBounds.min.y + _gameArea.localBounds.max.y) / 2,
                0);

            Building castle = Instantiate(_castelPrefab, castlePosition, Quaternion.identity);
            castle.SetBuildingAreaPosition(_buildingSystem.GridLayout.LocalToCell(castlePosition));
            castle.Init(_buildingSystem);
            TilemapHandler.SetTilesBlock(castle.BuildingArea, _buildingSystem.TileBase[TileType.Red], _fieldTilemap);
            _buildingSystem.ObjectManager.SetCastle(castle);
        }

        private void SpawnTrees()
        {
            BoundsInt boundry = new BoundsInt(CalculateResourcePosition(), RandomSizeBoundry());
            TileBase[] fieldTitleBase = TilemapHandler.GetTilesBlock(boundry, _fieldTilemap);

            if (CheckIfAreaIsOccupy(fieldTitleBase))
            {
                foreach (Vector3Int p in boundry.allPositionsWithin)
                    _buildingSystem.ObjectManager.AddTree(SpawnResource(_treePrefab, p));

                TilemapHandler.SetTilesBlock(boundry, _buildingSystem.TileBase[TileType.Red], _fieldTilemap);
            }
            else
            {
                SpawnTrees();
            }
        }

        private void SpawnStones()
        {
            BoundsInt boundry = new BoundsInt(CalculateResourcePosition(), RandomSizeBoundry());
            TileBase[] fieldTitleBase = TilemapHandler.GetTilesBlock(boundry, _fieldTilemap);

            if (CheckIfAreaIsOccupy(fieldTitleBase))
            {
                foreach (Vector3Int p in boundry.allPositionsWithin)
                    _buildingSystem.ObjectManager.AddStone(SpawnResource(_stonePrefab, p));

                TilemapHandler.SetTilesBlock(boundry, _buildingSystem.TileBase[TileType.Red], _fieldTilemap);
            }
            else
            {
                SpawnStones();
            }
        }
        private Vector3Int RandomSizeBoundry()
        {
            return new Vector3Int(
                Random.Range(_minBoundrySize, _maxBoundrySize),
                Random.Range(_minBoundrySize, _maxBoundrySize),
                1);
        }

        private Vector3Int CalculateResourcePosition()
        {
            int triangleIndex = Random.Range(0, 2);
            return _buildingSystem.GridLayout.LocalToCell(RandomWithinTriangle(_triangle[triangleIndex]));
        }

        private bool CheckIfAreaIsOccupy(TileBase[] tileBases)
        {
            for (int i = 0; i < tileBases.Length; i++)
            {
                if (tileBases[i] == _buildingSystem.TileBase[TileType.Red])
                    return false;
            }
            return true;
        }

        private Resource SpawnResource(Resource prefab, Vector3Int position)
        {
            Resource resource = Instantiate(prefab);
            resource.transform.localPosition = _buildingSystem.GridLayout.CellToLocalInterpolated(position);
            resource.transform.SetParent(transform);
            resource.SetBoundsPosition(position);
            return resource;
        }

    }
}
