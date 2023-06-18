using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Kingdom.UI
{
    public class PauseMenuUI : MonoBehaviour
    {
        [SerializeField] private string _nameOfMainMenuScene;
        [SerializeField] private Button _resumeGameButton;
        [SerializeField] private Button _backToMainMenuButton;

        private bool _isShow;

        private void Start()
        {
            GameManager.Instance.OnPasueStateChanged += GameManager_OnPasueStateChanged;
            _resumeGameButton.onClick.AddListener(() =>
            {
                Show();
                AudioManager.Instance.PlayButtonSound();
                GameManager.Instance.SetGameState(GameManager.GameState.None);
            });

            _backToMainMenuButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.PlayButtonSound();
                Loader.LoadScene(Loader.Scence.MainMenu);
            });
            Hide();
        }

        private void GameManager_OnPasueStateChanged(object sender, System.EventArgs e) => Show();
       

        private void Show()
        {
            _isShow = !_isShow;
            gameObject.SetActive(_isShow);
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1f;
                GameManager.Instance.SetGameState(GameManager.GameState.None);
                AudioManager.Instance.UnpauseAudio();
            }
            else if (Time.timeScale == 1)
            {
                Time.timeScale = 0f;
                AudioManager.Instance.PauseAudio();
            }
        }
        private void Hide() => gameObject.SetActive(false);

    }
}
