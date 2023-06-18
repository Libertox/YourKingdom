using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace Kingdom.UI
{
    public class InteractableButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Materials _demandResources;
        private Action _buttonAction;
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() =>
            {
                _buttonAction();
                AudioManager.Instance.PlayButtonSound();
            });
        }

        public void OnPointerEnter(PointerEventData eventData) => PlayerResources.Instance.ViewDemandingResources(_demandResources);

        public void OnPointerExit(PointerEventData eventData) => PlayerResources.Instance.UpdateOwnedResource();

        public void SetDemandResources(Materials demandResources) => _demandResources = demandResources;

        public void SetActionDelegate(Action action) => _buttonAction = action;

        public void SetDemandResourcesAndAction(Materials demandResources, Action action)
        {
            _demandResources = demandResources;
            _buttonAction = action;
        }

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);

    }
}
