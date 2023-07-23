using UnityEngine.UI;
using UnityEngine;
using UI.Settings;
using UI.Views;

namespace UI.Controllers
{
    [RequireComponent(typeof(TextButtonView))]
    public sealed class TextButtonController : ButtonController
    {
        [Header("Controller")]
        [SerializeField] private TextButtonView _view;
        [SerializeField] private Image _buttonImage;

        public void Setup(TextButtonSettings settings)
        {
            base.Setup(settings);

            _view?.SetText(settings.Title);
            SetButtonColor(settings.Color);
        }

        private void SetButtonColor(Color? color)
        {
            if (_buttonImage == null || color == null)
                return;

            _buttonImage.color = (Color)color;
        }
    }
}