using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{

    [CreateAssetMenu(fileName = "MusicAudioClips", menuName = "AudioClips/MusicAudioClips", order = 0)]
    public class MusicAudioClips : ScriptableObject
    {
        [SerializeField] private AudioClip _mainMenu;
        [SerializeField] private AudioClip _duringPlay;
        [SerializeField] private AudioClip _duringAttack;
        [SerializeField] private AudioClip _loseGame;
        [SerializeField] private AudioClip _victoryGame;

        public AudioClip MainMenu => _mainMenu;
        public AudioClip DuringPlay => _duringPlay;
        public AudioClip DuringAttack => _duringAttack;
        public AudioClip LoseGame => _loseGame;
        public AudioClip VictoryGame => _victoryGame;

    }
}
