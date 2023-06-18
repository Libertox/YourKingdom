using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Kingdom.MapHandler;

namespace Kingdom.BuildingObject
{
    public class Building : MonoBehaviour, IDamageable
    {
        public static event EventHandler OnSelected;
        public static event EventHandler OnUnselected;
        public enum State
        {
            Planned,
            Building,
            Built,
        }
        public int Level { get; private set; }

        protected float _health;
        protected BuildingSystem _buildingSystem;

        private SpriteRenderer _spriteRender;

        [SerializeField] private State _currentState;
        [SerializeField] private int _maxLevel;
        [SerializeField] private BuildingStats[] _buildingStats;
        [SerializeField] private Vector3Int _areaOffset;
        [SerializeField] private BoundsInt _area;

        [SerializeField] private GameObject _activeIndicator;

        [SerializeField] protected Bar _healthBar;
        [SerializeField] protected Bar _progressBar;
        [SerializeField] private BuildingButtons _buildingButtons;

        private float _waitingTimer;

        public BuildingStats BuildingStats => _buildingStats[Level];
        public BuildingButtons BuildingButtons => _buildingButtons;
        public Vector3Int AreaOffset => _areaOffset;
        public BoundsInt BuildingArea => _area;

        public virtual void Update()
        {
            if (IsBuilding())
            {
                if(GameManager.Instance.IsNoneState())
                    AudioManager.Instance.PlayBuiltSound();

                _waitingTimer += Time.deltaTime;
                _progressBar.ChangeFileOfBar(_waitingTimer / BuildingStats.MaxBuiltTime);
                if (_waitingTimer > BuildingStats.MaxBuiltTime)
                {
                    Built();
                    _waitingTimer = 0;
                    AudioManager.Instance.StopSoundEffect();
                }
            }
        }

        public static void ResetStaticData()
        {
            OnSelected = null;
            OnUnselected = null;
        }

        public virtual void Init(BuildingSystem buildingSystem)
        {
            _buildingSystem = buildingSystem;
            _spriteRender = GetComponent<SpriteRenderer>();
            _health = BuildingStats.MaximumHealth;
            _currentState = State.Planned;
            _buildingButtons.Init(buildingSystem);

        }

        public bool CanBePlaced()
        {
            BoundsInt areaTemp = _area;
            areaTemp.position = _buildingSystem.GridLayout.LocalToCell(transform.position + _areaOffset);

            if (_buildingSystem.CanTakeArea(areaTemp))
            {
                return true;
            }
            return false;
        }

        public void Place()
        {
            BoundsInt areaTemp = _area;
            areaTemp.position = _buildingSystem.GridLayout.LocalToCell(transform.position + _areaOffset);
            _currentState = State.Building;
            _progressBar.Show();
            _buildingButtons.Hide();
            ChangeColor(Color.white);
            _buildingSystem.TakeArea(areaTemp);
            GetComponent<NavMeshObstacle>().enabled = true;
        }

        public void ChangeColor(Color color) => _spriteRender.color = color;

        public void MoveBuilding()
        {
            if (IsPlanned())
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int cellPos = _buildingSystem.GridLayout.LocalToCell(touchPos);

                transform.localPosition = _buildingSystem.GridLayout.CellToLocalInterpolated(cellPos);

                _buildingSystem.FollowBuilding();
            }
        }

        public virtual void Built()
        {
            _currentState = State.Built;
            _progressBar.Hide();
        }

        public void RestoreHealth()
        {
            _health = BuildingStats.MaximumHealth;
            _healthBar.ChangeFileOfBar(_health);
        }
        public void Repair()
        {
            if (PlayerResources.Instance.CheckEnoughResources(BuildingStats.RepaireResources))
            {
                PlayerResources.Instance.SubstractMaterials(BuildingStats.RepaireResources);
                RestoreHealth();
            }
        }

        public void Upgrade()
        {
            if (PlayerResources.Instance.CheckEnoughResources(BuildingStats.UpgradeResources))
            {
                PlayerResources.Instance.SubstractMaterials(BuildingStats.UpgradeResources);
                LevelUp();
                Selected();
            }
        }

        public virtual void Sell()
        {
            PlayerResources.Instance.AddMaterials(BuildingStats.SellResources);
            AudioManager.Instance.PlaySellingSound();
            DestroySelf();
        }

        public virtual void LevelUp()
        {
            if (CheckBuildingIsNotMaxLevel())
            {
                Level++;
                _spriteRender.sprite = BuildingStats.Texture;
                RestoreHealth();
            }
        }

        public virtual void Selected()
        {
            if (IsBuilt())
            {
                OnSelected?.Invoke(this, EventArgs.Empty);
                SetVisibleSelectedIndicator(true);
                _healthBar.Show();
            }
        }

        public void UnSelected()
        {
            if (IsBuilt())
            {
                OnUnselected?.Invoke(this, EventArgs.Empty);
                HideUIElement();
            }
        }

        public virtual void HideUIElement()
        {
            SetVisibleSelectedIndicator(false);
            _healthBar.Hide();
        }

        public bool CheckBuildingIsNotMaxLevel() => Level < _maxLevel;

        public bool IsPlanned() => _currentState == State.Planned;

        public bool IsBuilding() => _currentState == State.Building;

        public bool IsBuilt() => _currentState == State.Built;

        public void SetBuildingAreaPosition(Vector3Int posiiton) => _area.position = posiiton;

        public void SetVisibleSelectedIndicator(bool active) => _activeIndicator.SetActive(active);


        #region ------- IDamageable Implementation ---------

        public virtual void CheckHealthStatus()
        {
            if (_health > 0)
            {
                if (_health < BuildingStats.MaximumHealth)
                {
                    _healthBar.Show();
                }
            }
            else
            {
                GameManager.Instance.GameStatistic.AddLoseBuidling();
                DestroySelf();
            }
        }
        public void GetDamage(int damage)
        {
            _health -= damage;
            float currentHealth = (_health / BuildingStats.MaximumHealth);
            _healthBar.ChangeFileOfBar(currentHealth);

            CheckHealthStatus();

        }
        public Vector3 GetPosition() => transform.position;
        public virtual void DestroySelf()
        {
            UnSelected();
            TilemapHandler.SetTilesBlock(BuildingArea, _buildingSystem.TileBase[TileType.White], _buildingSystem.FieldTilemap);
            Destroy(gameObject);
        }
        public bool IsExist() => (this != null);

        #endregion

    }
}