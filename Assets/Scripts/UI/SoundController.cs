using UnityEngine.UI;
using UnityEngine;
using Settings;
using Modules;
using Core;

namespace UI.Controllers
{
    [RequireComponent(typeof(Button))]
    public sealed class SoundController : MonoBehaviour
    {
        [SerializeField] private SoundEffectType _effectType;
        [SerializeField] private Button _button;

        private AudioClip _audioClip;

        private void OnClick()
        {
            if (_audioClip == null)
                return;

            SoundProvider.PlaySoundEffect(_audioClip);
        }

        private void Awake()
        {
            _audioClip = SettingsProvider.Get<SoundsSettings>().GetAudioClip(_effectType);
            _button?.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            _button?.onClick?.RemoveListener(OnClick);
        }
    }
}