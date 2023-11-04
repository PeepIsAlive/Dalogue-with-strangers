using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using Settings;
using Modules;
using Core;

namespace UI.Controllers
{
    [RequireComponent(typeof(Button))]
    public sealed class SoundController : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private SoundEffectType _effectType;
        private AudioClip _audioClip;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_audioClip == null)
                return;

            SoundProvider.PlaySoundEffect(_audioClip);
        }

        private void Awake()
        {
            _audioClip = SettingsProvider.Get<SoundsSettings>().GetAudioClip(_effectType);
        }
    }
}