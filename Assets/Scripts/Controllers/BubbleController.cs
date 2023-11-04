using DG.Tweening;
using UnityEngine;
using Modules;
using Events;
using TMPro;

namespace Controllers
{
    public sealed class BubbleController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;

        public void AddText(string text)
        {
            if (_label == null)
                return;

            _label.text += $"{text} ";
        }

        private void ClearBubbleText(OnMessageSendEvent data)
        {
            if (_label == null)
                return;

            _label.text = string.Empty;
        }

        private void OnEnable()
        {
            var startSize = transform.localScale;
            var endSize = new Vector3(0f, 0f, 1f);

            transform.localScale = endSize;
            transform.DOScale(startSize, 0.15f)
                .SetLink(gameObject)
                .SetEase(Ease.Linear)
                .OnKill(() =>
                {
                    EventSystem.Send<OnStartDialogEvent>();
                });
        }

        private void Start()
        {
            EventSystem.Subscribe<OnMessageSendEvent>(ClearBubbleText);
        }

        private void OnDestroy()
        {
            EventSystem.Unsubscribe<OnMessageSendEvent>(ClearBubbleText);
        }
    }
}