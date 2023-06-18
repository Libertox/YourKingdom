using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kingdom
{
    public class Bar : MonoBehaviour
    {
        [SerializeField] private Image _Bar;

        public void ChangeFileOfBar(float fillStatus) => _Bar.fillAmount = fillStatus;

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);

    }
}
