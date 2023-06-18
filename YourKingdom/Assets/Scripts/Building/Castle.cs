using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.MapHandler;

namespace Kingdom.BuildingObject
{
    public class Castle : Building
    {
        public override void Init(BuildingSystem buildingSystem)
        {
            _buildingSystem = buildingSystem;
            _health = BuildingStats.MaximumHealth;
        }


        public override void CheckHealthStatus()
        {
            if (_health > 0)
            {
                if (_health < BuildingStats.MaximumHealth)
                    _healthBar.Show();
            }
            else
            {
                GameManager.Instance.GameStatistic.AddLoseBuidling();
                GameManager.Instance.SetGameState(GameManager.GameState.GameOver);
                DestroySelf();
            }
        }



        public override void Sell() { }

    }
}
