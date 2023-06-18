using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{
    public class PlayerResources : MonoBehaviour
    {
        public static PlayerResources Instance { get; private set; }

        public event EventHandler<OnResourcesChangedEventArgs> OnLumbermanAmountChanged;
        public event EventHandler<OnResourcesChangedEventArgs> OnMinerAmountChanged;
        public event EventHandler<OnResourcesChangedEventArgs> OnWarriorAmountChanged;
        public event EventHandler<OnResourcesChangedEventArgs> OnWarriorLevelTwoAmountChanged;
        public event EventHandler<OnResourcesChangedEventArgs> OnArcherAmountChanged;
        public event EventHandler<OnResourcesChangedEventArgs> OnWizardAmountChanged;

        public class OnResourcesChangedEventArgs : EventArgs { public int resourceChaged; }


        public event EventHandler<OnOwnedResourceAmountChangedEventArgs> OnDemandResourceShowed;
        public event EventHandler<OnOwnedResourceAmountChangedEventArgs> OnOwnedResourceAmountChanged;
        public class OnOwnedResourceAmountChangedEventArgs : EventArgs { public Materials materials; }


        [SerializeField] private Materials _ownedResources;
        private int _luberman;
        private int _miner;
        private int _warrior;
        private int _warriorLevelTwo;
        private int _archer;
        private int _wizard;

        public Materials OwnedResources => _ownedResources;

        private void Awake()
        {
            if (!Instance)
                Instance = this;
        }

        public void AddWoodAmount(int amount)
        {
            _ownedResources.wood += amount;
            UpdateOwnedResource();
        }

        public void AddStoneAmount(int amount)
        {
            _ownedResources.stone += amount;
            UpdateOwnedResource();
        }

        public void AddGrainAmount(int amount)
        {
            _ownedResources.grain += amount;
            UpdateOwnedResource();
        }

        public void AddLubermanAmount(int amount)
        {
            _luberman += amount;
            OnLumbermanAmountChanged?.Invoke(this, new OnResourcesChangedEventArgs
            {
                resourceChaged = _luberman
            });
        }

        public void AddMinerAmount(int amount)
        {
            _miner += amount;
            OnMinerAmountChanged?.Invoke(this, new OnResourcesChangedEventArgs
            {
                resourceChaged = _miner
            }); ;
        }

        public void AddWarriorAmount(int amount)
        {
            _warrior += amount;
            OnWarriorAmountChanged?.Invoke(this, new OnResourcesChangedEventArgs
            {
                resourceChaged = _warrior
            });
        }

        public void AddWarriorLevelTwoAmount(int amount)
        {
            _warriorLevelTwo += amount;
            OnWarriorLevelTwoAmountChanged?.Invoke(this, new OnResourcesChangedEventArgs
            {
                resourceChaged = _warriorLevelTwo
            });
        }

        public void AddArcherAmount(int amount)
        {
            _archer += amount;
            OnArcherAmountChanged?.Invoke(this, new OnResourcesChangedEventArgs
            {
                resourceChaged = _archer
            });
        }

        public void AddWizardAmount(int amount)
        {
            _wizard += amount;
            OnWizardAmountChanged?.Invoke(this, new OnResourcesChangedEventArgs
            {
                resourceChaged = _wizard
            });
        }

        public void UpdateOwnedResource()
        {
            OnOwnedResourceAmountChanged?.Invoke(this, new OnOwnedResourceAmountChangedEventArgs
            {
                materials = _ownedResources
            });
        }

        public void ViewDemandingResources(Materials resources)
        {
            OnDemandResourceShowed?.Invoke(this, new OnOwnedResourceAmountChangedEventArgs
            {
                materials = resources
            });
        }

        public bool CheckEnoughResources(Materials resources)
        {
            if (resources <= _ownedResources)
            {
                return true;
            }
            return false;
        }

        public void SubstractMaterials(Materials resources)
        {
            _ownedResources -= resources;
            UpdateOwnedResource();
        }

        public void AddMaterials(Materials materials)
        {
            _ownedResources += materials;
            UpdateOwnedResource();
        }

    }
}