using UnityEngine;

namespace Modules
{
    public sealed class SoundProvider : MonoBehaviour
    {
        public static SoundProvider Instance { get; private set; }
        private AudioSource _audioSource;

        public static void PlaySoundEffect(AudioClip clip, int volume = 100)
        {
            if (Instance == null && clip == null)
                return;

            Instance._audioSource.volume = volume;
            Instance._audioSource.PlayOneShot(clip);
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