using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom.MapHandler;

namespace Kingdom.BuildingObject
{
    public class Mill : Building
    {
        private float _progress;
        private MillStats _millStats;

        public override void Update()
        {
            base.Update();
            if (IsBuilt())
            {
                _progress += Time.deltaTime;
                _progressBar.ChangeFileOfBar(_progress / _millStats.Cooldown);
                if (_progress > _millStats.Cooldown)
                {
                    _progress = 0;
                    PlayerResources.Instance.AddGrainAmount(_millStats.GrainAdded);
                }
            }
        }
        public override void Init(BuildingSystem buildingSystem)
        {
            base.Init(buildingSystem);
            _millStats = (MillStats)BuildingStats;
        }

        public override void LevelUp()
        {
            base.LevelUp();
            _millStats = (MillStats)BuildingStats;
        }
        public override void Built()
        {
            base.Built();
            _progressBar.Show();
        }
    }
}
