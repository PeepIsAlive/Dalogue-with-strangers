using UnityEngine;
using UI.Settings;
using UI.Views;

namespace UI.Controllers
{
    [RequireComponent(typeof(ImageButtonView))]
    public sealed class ImageViewController : ButtonController
    {
        [Header("Controller")]
        [SerializeField] private ImageButtonView _view;

        public void Setup(ImageButtonSettings settings)
        {
            base.Setup(settings);

            _view?.SetIcon(settings.Icon);
        }
    }
}