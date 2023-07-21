using Application = Live_2D.Application;
using System.Collections.Generic;
using UnityEngine.UI;
using UI.Controllers;
using UnityEngine;
using DG.Tweening;
using UI.Settings;
using System.Linq;
using Settings;

namespace UI
{
    public class PopupView<T> : PopupViewBase where T : Popup
    {
        [Header("Base")]
        [SerializeField] private RectTransform _rootRect;
        [SerializeField] private Button _overlayButton;

        [Header("Blocks")]
        [SerializeField] private RectTransform _topParent;
        [SerializeField] private RectTransform _middleParent;
        [SerializeField] private RectTransform _buttonParent;

        private readonly float _durationTween = 0.3f;
        private bool _ignoreOverlayButtonAction;

        public virtual void Setup(T settings)
        {
            _ignoreOverlayButtonAction = settings.IgnoreOverlayButtonAction;
        }

        public override void Show()
        {
            base.Show();

            AddListeners();
            DoShow();
        }

        public override void Hide()
        {
            base.Hide();

            RemoveListeners();
            DoHide();
        }

        protected void InitializeButtons<S>(List<S> buttonSettings) where S : ButtonSettings
        {
            var prefabsSet = SettingsProvider.Get<PrefabsSet>();

            foreach (var setting in buttonSettings)
            {
                if (setting is TextButtonSettings textButtonSettings)
                {
                    var prefab = prefabsSet.Buttons.First(x => x.GetComponent<TextButtonController>() != null)
                        .GetComponent<TextButtonController>();

                    Instantiate(prefab, _buttonParent, false)
                        .Setup(textButtonSettings);
                }
            }
        }

        private void DoShow()
        {
            _rootRect ??= gameObject.GetComponent<RectTransform>();

            var startOffset = Vector3.down.normalized * Application.MainCanvasRect.sizeDelta.y;
            var targetPosition = _rootRect.localPosition;

            if (Mathf.Abs(startOffset.sqrMagnitude) - Mathf.Abs(Vector2.zero.sqrMagnitude) > Mathf.Epsilon)
            {
                _rootRect.localPosition += startOffset;
                _rootRect.DOAnchorPos(targetPosition, _durationTween)
                    .SetEase(Ease.OutBack)
                    .OnComplete(() => _overlayButton.gameObject.SetActive(true));
            }
        }

        private void DoHide()
        {
            var targetPosition = Vector3.down.normalized * Application.MainCanvasRect.sizeDelta.y;

            if (Mathf.Abs(targetPosition.sqrMagnitude) - Mathf.Abs(Vector2.zero.sqrMagnitude) > Mathf.Epsilon)
            {
                _overlayButton.gameObject.SetActive(false);
                _rootRect.DOAnchorPos(targetPosition, _durationTween)
                    .SetEase(Ease.InBack)
                    .OnComplete(() => Destroy(gameObject));
            }
        }

        private void AddListeners()
        {
            if (!_ignoreOverlayButtonAction)
                _overlayButton?.onClick.AddListener(Hide);
        }

        private void RemoveListeners()
        {
            _overlayButton?.onClick?.RemoveListener(Hide);
        }
    }
}
