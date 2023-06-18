using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kingdom.UI
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private Slider _sfxSlider;
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Button _resumeButton;

        private bool _isShow;

        private void Start()
        {
            GameManager.Instance.OnSettingStateChanged += GameManager_OnSettingStateChanged;

            _resumeButton.onClick.AddListener(() =>
            {
                Show();
                AudioManager.Instance.PlayButtonSound();
                GameManager.Instance.SetGameState(GameManager.GameState.None);
            });

            _sfxSlider.onValueChanged.AddListener((float value) => AudioManager.Instance.SetSoundEffectVolume(value));

            _musicSlider.onValueChanged.AddListener((float value) => AudioManager.Instance.SetMusicVolume(value));

            _sfxSlider.value = AudioManager.Instance.SoundEffectVolume;
            _musicSlider.value = AudioManager.Instance.MusicVolume;

            Hide();
        }

        private void GameManager_OnSettingStateChanged(object sender, System.EventArgs e) => Show();
       

        private void Show()
        {
            _isShow = !_isShow;
            gameObject.SetActive(_isShow);
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1f;
                GameManager.Instance.SetGameState(GameManager.GameState.None);
            }
            else if (Time.timeScale == 1)
                Time.timeScale = 0f;
        }
        private void Hide() => gameObject.SetActive(false);


    }
}