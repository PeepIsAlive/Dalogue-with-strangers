using UnityEngine;
using TMPro;

namespace UI
{
    public sealed class DefaultPopupView : PopupView<DefaultPopup>
    {
        [Header("View")]
        [SerializeField] private TMP_Text _titleLabel;
        [SerializeField] private TMP_Text _contentLabel;

        public override void Setup(DefaultPopup settings)
        {
            base.Setup(settings);

            SetTitleText(settings.Title);
            SetContentText(settings.Content);
            InitializeButtons(settings.ButtonSettings);
        }

        private void SetTitleText(string text)
        {
            if (_titleLabel == null)
                return;

            _titleLabel.text = text;
        }

        private void SetContentText(string text)
        {
            if (_contentLabel == null)
                return;

            _contentLabel.text = text;
        }
    }
}
