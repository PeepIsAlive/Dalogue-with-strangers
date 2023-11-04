using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "SoundsSettings", menuName = "Settings/SoundsSettings", order = 0)]
    public sealed class SoundsSettings : ScriptableObject
    {
        [SerializeField] private List<Sound> _sounds; 

        public AudioClip GetAudioClip(SoundEffectType soundType)
        {
            return _sounds.First(s => s.Type == soundType).AudioClip;
        }


        [Serializable]
        public sealed class Sound
        {
            [field: SerializeField] public SoundEffectType Type { get; private set; }
            [field: SerializeField] public AudioClip AudioClip { get; private set; }
        }
    }
}