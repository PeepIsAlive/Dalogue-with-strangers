using MoreMountains.NiceVibrations;
using UnityEngine.EventSystems;
using UnityEngine;
using Modules;

namespace UI.Controllers
{
    public sealed class HapticController : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private HapticTypes _hapticType;

        public void OnPointerDown(PointerEventData eventData)
        {
            HapticProvider.Haptic(_hapticType);
        }
    }
}