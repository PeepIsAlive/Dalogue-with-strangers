using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace UI
{
    public sealed class DefaultPopupView : PopupView<DefaultPopup>
    {
        [Header("View")]
        [SerializeField] private TMP_Text _titleLabel;
        [SerializeField] private TMP_Text _contentLabel;
        [SerializeField] private Image _headerImage;

        public override void Setup(DefaultPopup settings)
        {
            base.Setup(settings);

            SetTitleText(settings.Title, settings.Color);
            SetContentText(settings.Content, settings.Color);
            InitializeButtons(settings.ButtonSettings, settings.Color);
        }

        private void SetTitleText(string text, Color? color = null)
        {
            if (_titleLabel == null || _headerImage == null)
                return;

            _titleLabel.text = text;
            _headerImage.color = (Color)color;
        }

        private void SetContentText(string text, Color? color = null)
        {
            if (_contentLabel == null)
                return;

            _contentLabel.text = text;
            _contentLabel.color = (Color)color;
        }
    }
}
