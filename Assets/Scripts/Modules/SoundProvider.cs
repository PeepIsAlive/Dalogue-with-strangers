using UnityEngine;

namespace Modules
{
    public sealed class SoundProvider : MonoBehaviour
    {
        public static SoundProvider Instance { get; private set; }
        public static bool State { get; private set; } = true;

        private AudioSource _audioSource;

        public static void PlaySoundEffect(AudioClip clip, int volume = 100)
        {
            if ((Instance == null || clip == null) || !State)
                return;

            Instance._audioSource.volume = volume;
            Instance._audioSource.PlayOneShot(clip);
        }

        public static void SwitchState()
        {
            State  = !State;
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _audioSource = transform.GetChild(0).GetComponent<AudioSource>();
        }
    }
}