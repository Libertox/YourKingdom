using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Kingdom.UI
{
    public class WaveTimerUI : MonoBehaviour
    {
        private const string SourceText = "Attack!!!";
        [SerializeField] private TextMeshProUGUI _waveTimerText;

        private void Start() => EnemySpawnerManager.Instance.OnAttackStateChagned += EnemySpawnerManager_OnAttackStateChagned;

        private void EnemySpawnerManager_OnAttackStateChagned(object sender, System.EventArgs e) => _waveTimerText.SetText(SourceText);

        private void Update()
        {
            if (EnemySpawnerManager.Instance.IsWaitState())
                _waveTimerText.SetText(Mathf.Ceil(EnemySpawnerManager.Instance.WaitingTimeBetweenState).ToString());
        }
    }
}
