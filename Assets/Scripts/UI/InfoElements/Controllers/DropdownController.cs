using UnityEngine;
using UI.Settings;
using UI.Views;
using TMPro;

namespace UI.Controllers
{
    [RequireComponent(typeof(DropdownView), typeof(TMP_Dropdown))]
    public sealed class DropdownController : MonoBehaviour
    {
        private TMP_Dropdown _dropdown;
        private DropdownView _view;

        public string GetCurrentValue()
        {
            return _dropdown.options[_dropdown.value].text;
        }

        public void Setup(DropdownSettings settings)
        {
            _dropdown.options = settings.OptionDataList.options;

            _view.SetTitle(settings.Title);
            _view.SetColor(settings.Color);
        }

        private void Awake()
        {
            _dropdown = GetComponent<TMP_Dropdown>();
            _view = GetComponent<DropdownView>();
        }
    }
}