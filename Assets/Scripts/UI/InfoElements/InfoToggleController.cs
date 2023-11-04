using UnityEngine.UI;
using UI.Settings;
using UnityEngine;
using UI.Views;

namespace UI.Controllers
{
    [RequireComponent(typeof(InfoToggleView), typeof(Button))]
    public sealed class InfoToggleController : MonoBehaviour
    {
        [SerializeField] private InfoToggleView _view;
        [SerializeField] private Button _button;

        public void Setup(InfoToggleSettings settings)
        {
            _view.SetText(settings.Content);
            _view.SetColor(settings.Color);

            _button.onClick.AddListener(() =>
            {
                _view.SetCheckmarkState(settings.Action.Invoke());
            });
        }

        private void OnDestroy()
        {
            _button.onClick?.RemoveAllListeners();
        }
    }
}