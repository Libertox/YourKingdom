using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Kingdom.UI
{
    public class WaveNumberUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _waveNumberText;
        [SerializeField] private float _cooldownShowText;

        private bool _show;
        private float _displayTimer;
        private CanvasGroup _canvasGroup;

        private void Awake() => _canvasGroup = GetComponent<CanvasGroup>();

        private void Start()
        {
            EnemySpawnerManager.Instance.OnAttackStateChagned += EnemySpawnerManager_OnAttackStateChagned;
            Hide();
        }
        private void Update()
        {
            if (_show)
            {
                _canvasGroup.alpha = Mathf.MoveTowards(_canvasGroup.alpha, 1f, Time.deltaTime);
                if (_canvasGroup.alpha == 1f)
                {
                    _displayTimer += Time.deltaTime;
                    if (_displayTimer > _cooldownShowText)
                        _show = false;
                }
            }
            else
            {
                _canvasGroup.alpha = Mathf.MoveTowards(_canvasGroup.alpha, 0f, Time.deltaTime);
                if (_canvasGroup.alpha == 0f)
                    Hide();
            }

        }

        private void EnemySpawnerManager_OnAttackStateChagned(object sender, System.EventArgs e)
        {
            Show();
            _waveNumberText.SetText($"WAVE : {EnemySpawnerManager.Instance.WaveNumber}");
            _show = true;
        }

        private void Show() => gameObject.SetActive(true);

        private void Hide() => gameObject.SetActive(false);
    }
}
