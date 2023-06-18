using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kingdom.MapHandler;

namespace Kingdom.BuildingObject
{
    public class BuildingButtons : MonoBehaviour
    {
        [SerializeField] private Button acceptBuiltButton;
        [SerializeField] private Button cancelBuiltButton;

        public void Init(BuildingSystem buildingSystem)
        {
            acceptBuiltButton.onClick.AddListener(() =>
            {
                buildingSystem.PutBuilding();
            });
            cancelBuiltButton.onClick.AddListener(() =>
            {
                buildingSystem.SetSelectedMode(TypeOfBuildingModification.None);
            });
        }

        public void Hide() => gameObject.SetActive(false);
    }
}
