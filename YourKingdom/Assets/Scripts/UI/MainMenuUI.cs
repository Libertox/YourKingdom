using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Kingdom.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _soundEffectSlider;

        private void Start()
        {
            AudioManager.Instance.PlayMainMenuMusic();
            _playButton.Select();

            _playButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.PlayButtonSound();
                Loader.LoadScene(Loader.Scence.Game);
            });
        
            _exitButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.PlayButtonSound();
#if !UNITY_WEBGL
                Application.Quit();
#endif
            });

            _soundEffectSlider.onValueChanged.AddListener((float value) => AudioManager.Instance.SetSoundEffectVolume(value));

            _musicSlider.onValueChanged.AddListener((float value) => AudioManager.Instance.SetMusicVolume(value));

            _musicSlider.value = AudioManager.Instance.MusicVolume;
            _soundEffectSlider.value = AudioManager.Instance.SoundEffectVolume;

        }
    }
}
