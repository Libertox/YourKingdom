using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Kingdom.BuildingObject;

namespace Kingdom.MapHandler
{

    public class BuildingSystem : MonoBehaviour
    {
        public static BuildingSystem Instance { get; private set; }

        public event EventHandler OnStateNoned;
        public event EventHandler OnStateBuiled;
        public event EventHandler OnStateRemoved;

        [SerializeField] private GridLayout _gridLayout;
        [SerializeField] private TileBaseSO tileBaseSO;
        [SerializeField] private Tilemap _fieldTilemap;
        [SerializeField] private Tilemap _tempTilemap;

        private Building temp;
        private BoundsInt prevArea;
        private TypeOfBuildingModification selectedMode;

        public MapObjects ObjectManager { get; private set; }
        public Dictionary<TileType, TileBase> TileBase { get; private set; }
        public GridLayout GridLayout => _gridLayout;
        public Tilemap FieldTilemap => _fieldTilemap;
        public Tilemap TempTilemap => _tempTilemap;

        private void Awake()
        {
            if (!Instance)
                Instance = this;

            ObjectManager = new MapObjects();

            TileBase = new Dictionary<TileType, TileBase>
            {
                { TileType.Empty, null },
                { TileType.Red, tileBaseSO.RedTileBase },
                { TileType.Green, tileBaseSO.GreenTileBase },
                { TileType.White, tileBaseSO.WhiteTileBase }
            };
        }

        private void Start()
        {
            GameInput.Instance.OnBuilted += GameInput_OnBuilted;
            GameInput.Instance.OnCancelBuilt += GameInput_OnCancelBuilt;
        }

        private void GameInput_OnCancelBuilt(object sender, System.EventArgs e) => SetSelectedMode(TypeOfBuildingModification.None);

        private void GameInput_OnBuilted(object sender, System.EventArgs e) => PutBuilding();

        public void SetSelectedMode(TypeOfBuildingModification type)
        {
            switch (type)
            {
                case TypeOfBuildingModification.Bulid:
                    ShowModificationTilemap();
                    OnStateBuiled?.Invoke(this, EventArgs.Empty);
                    break;

                case TypeOfBuildingModification.Remove:
                    ShowModificationTilemap();
                    OnStateRemoved?.Invoke(this, EventArgs.Empty);
                    break;

                case TypeOfBuildingModification.None:
                    if (temp)
                    {
                        if (IsBuiltMode())
                            CancelBuilding();
                        temp = null;
                    }
                    HideModificationTilemap();
                    OnStateNoned?.Invoke(this, EventArgs.Empty);
                    break;
            }
            selectedMode = type;

        }

        public bool IsBuiltMode() => selectedMode == TypeOfBuildingModification.Bulid;

        public bool IsRemoveMode() => selectedMode == TypeOfBuildingModification.Remove;

        public bool IsNoneMode() => selectedMode == TypeOfBuildingModification.None;

        private void ShowModificationTilemap()
        {
            FieldTilemap.gameObject.SetActive(true);
            TempTilemap.gameObject.SetActive(true);
        }

        private void HideModificationTilemap()
        {
            FieldTilemap.gameObject.SetActive(false);
            TempTilemap.gameObject.SetActive(false);
        }

        public void InitializeWithBuilding(Building building)
        {
            if (!temp)
            {
                SetSelectedMode(TypeOfBuildingModification.Bulid);

                Vector2 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                Vector3Int cellPos = GridLayout.LocalToCell(touchPos);

                temp = Instantiate(building);
                temp.transform.localPosition = GridLayout.CellToLocalInterpolated(cellPos);
                temp.Init(this);
                FollowBuilding();
            }

        }

        public void FollowBuilding()
        {
            TilemapHandler.SetTilesBlock(prevArea, TileBase[TileType.Empty], _tempTilemap);

            temp.SetBuildingAreaPosition(_gridLayout.WorldToCell(temp.gameObject.transform.position + temp.AreaOffset));

            TileBase[] baseArray = TilemapHandler.GetTilesBlock(temp.BuildingArea, _fieldTilemap);

            int size = baseArray.Length;
            TileBase[] tileArray = new TileBase[size];

            for (int i = 0; i < baseArray.Length; i++)
            {
                if (baseArray[i] == TileBase[TileType.White] && PlayerResources.Instance.CheckEnoughResources(temp.BuildingStats.BuildResources))
                {
                    tileArray[i] = TileBase[TileType.Green];
                    temp.ChangeColor(Color.green);
                }
                else
                {
                    TilemapHandler.FileTiles(tileArray, TileBase[TileType.Red]);
                    temp.ChangeColor(Color.red);
                    break;
                }
            }
            _tempTilemap.SetTilesBlock(temp.BuildingArea, tileArray);
            prevArea = temp.BuildingArea;
        }

        public bool CanTakeArea(BoundsInt area)
        {
            TileBase[] baseArray = TilemapHandler.GetTilesBlock(area, _fieldTilemap);
            foreach (TileBase tilteBase in baseArray)
            {
                if (tilteBase != TileBase[TileType.White])
                    return false;
            }
            return true;
        }

        public void TakeArea(BoundsInt area)
        {
            TilemapHandler.SetTilesBlock(area, TileBase[TileType.Empty], _tempTilemap);
            TilemapHandler.SetTilesBlock(area, TileBase[TileType.Green], _fieldTilemap);
        }

        public void PutBuilding()
        {
            if (temp)
            {
                if (temp.CanBePlaced() && PlayerResources.Instance.CheckEnoughResources(temp.BuildingStats.BuildResources))
                {
                    temp.Place();
                    PlayerResources.Instance.SubstractMaterials(temp.BuildingStats.BuildResources);
                    temp = null;
                }
            }
        }

        public void CancelBuilding()
        {
            TilemapHandler.SetTilesBlock(prevArea, TileBase[TileType.Empty], _tempTilemap);
            temp.BuildingButtons.Hide();
            Destroy(temp.gameObject);
        }
    }
}