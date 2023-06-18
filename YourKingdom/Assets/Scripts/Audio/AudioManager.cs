using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{
    public class AudioManager : MonoBehaviour
    {
        private const string PREFS_MUSIC_VOLUME = "MusicVolume";
        private const string PREFS_SOUND_EFFECT_VOLUME = "SoundEffectVolume";
        public static AudioManager Instance { get; private set; }

        [SerializeField] private MusicAudioClips _musicAudioClips;
        [SerializeField] private SoundEffectAudioClips _soundEffectAudioClips;

        [SerializeField] private AudioSource _musicAudioSource;
        [SerializeField] private AudioSource _soundEffectAudioSource;

        public float SoundEffectVolume { get; private set; } = 1;
        public float MusicVolume => _musicAudioSource.volume;
        private void Awake()
        {
            if (!Instance)
                Instance = this;

            _musicAudioSource.volume = PlayerPrefs.GetFloat(PREFS_MUSIC_VOLUME);
        }

        private void Start()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnGameOverStateChanged += GameManager_OnGameOverStateChanged;
                GameManager.Instance.OnCompleteStateChanged += GameManager_OnCompleteStateChanged;
            }

            if (EnemySpawnerManager.Instance)
            {
                EnemySpawnerManager.Instance.OnAttackStateChagned += EnemySpawnerManager_OnAttackStateChagned;
                EnemySpawnerManager.Instance.OnPreparingStateChanged += EnemySpawnerManager_OnPreparingStateChanged;
            }

        }

        private void GameManager_OnCompleteStateChanged(object sender, System.EventArgs e)
        {
            StopSoundEffect();
            _musicAudioSource.clip = _musicAudioClips.VictoryGame;
            PlayMusic();
        }

        private void GameManager_OnGameOverStateChanged(object sender, System.EventArgs e)
        {
            StopSoundEffect();
            _musicAudioSource.clip = _musicAudioClips.LoseGame;
            PlayMusic();
        }

        private void EnemySpawnerManager_OnPreparingStateChanged(object sender, System.EventArgs e) => PlayGameplayMusic();

        private void EnemySpawnerManager_OnAttackStateChagned(object sender, System.EventArgs e) => PlayAttackMusic();

        public void PlayGameplayMusic()
        {
            _musicAudioSource.clip = _musicAudioClips.DuringPlay;
            PlayMusic();
        }

        public void PlayAttackMusic()
        {
            _musicAudioSource.clip = _musicAudioClips.DuringAttack;
            PlayMusic();
        }

        public void PlayMainMenuMusic()
        {
            _musicAudioSource.clip = _musicAudioClips.MainMenu;
            PlayMusic();
        }

        public void PlayButtonSound()
        {
            _soundEffectAudioSource.PlayOneShot(_soundEffectAudioClips.Button[Random.Range(0, _soundEffectAudioClips.Button.Length)], SoundEffectVolume);
        }

        public void PlayUnitRecruitmentSound()
        {
            _soundEffectAudioSource.PlayOneShot(_soundEffectAudioClips.UnitRecruitment, SoundEffectVolume);
        }

        public void PlayBuiltSound()
        {
            if (!_soundEffectAudioSource.isPlaying)
                _soundEffectAudioSource.PlayOneShot(_soundEffectAudioClips.Built, SoundEffectVolume);
        }
        public void PlaySellingSound()
        {
            _soundEffectAudioSource.PlayOneShot(_soundEffectAudioClips.Sell, SoundEffectVolume);
        }

        public void StopSoundEffect() => _soundEffectAudioSource.Stop();

        public void PauseAudio()
        {
            _musicAudioSource.Pause();
            _soundEffectAudioSource.Pause();
        }
        public void UnpauseAudio()
        {
            _musicAudioSource.UnPause();
            _soundEffectAudioSource.UnPause();
        }

        public void PlayMusic()
        {
            if (!_musicAudioSource.isPlaying)
                _musicAudioSource.Play();
        }

        public void SetMusicVolume(float volume)
        {
            _musicAudioSource.volume = volume;
            PlayerPrefs.SetFloat(PREFS_MUSIC_VOLUME, _musicAudioSource.volume);
            PlayerPrefs.Save();
        }

        public void SetSoundEffectVolume(float volume)
        {
            SoundEffectVolume = volume;
            PlayerPrefs.SetFloat(PREFS_SOUND_EFFECT_VOLUME, SoundEffectVolume);
            PlayerPrefs.Save();
        }
    }
}