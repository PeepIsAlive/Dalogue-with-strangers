using UnityEngine;
using TMPro;

namespace UI
{
    public sealed class DefaultPopupView : PopupView<DefaultPopup>
    {
        [Header("View")]
        [SerializeField] private TMP_Text _contentLabel;

        public override void Setup(DefaultPopup settings)
        {
            base.Setup(settings);
            SetContentText(settings.Content, settings.Color);
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
