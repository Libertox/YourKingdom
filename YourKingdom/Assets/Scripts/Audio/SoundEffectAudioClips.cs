using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{

    [CreateAssetMenu(fileName = "SoundEffectAudioClips", menuName = "AudioClips/SoundEffectAudioClips", order = 1)]
    public class SoundEffectAudioClips : ScriptableObject
    {
        [SerializeField] private AudioClip[] _button;
        [SerializeField] private AudioClip _unitRecruitment;
        [SerializeField] private AudioClip _built;
        [SerializeField] private AudioClip _sell;

        public AudioClip[] Button => _button;
        public AudioClip UnitRecruitment => _unitRecruitment;
        public AudioClip Built => _built;
        public AudioClip Sell => _sell;
    }
}
