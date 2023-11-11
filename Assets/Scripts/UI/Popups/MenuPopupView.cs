using System.Collections.Generic;
using UI.Controllers;
using UI.Settings;
using UnityEngine;
using Settings;

namespace UI
{
    public sealed class MenuPopupView : PopupView<MenuPopup>
    {
        [Header("View")]
        [SerializeField] private RectTransform _toggleParent;

        [Header("Dropdown")]
        [SerializeField] private DropdownController _dropdownController;

        public override void Setup(MenuPopup settings)
        {
            base.Setup(settings);

            SetDropdown(settings.DropdownSettings);
            SetToggles(settings.InfoToggleSettings);
        }

        private void SetToggles(List<InfoToggleSettings> settings)
        {
            if (_toggleParent == null)
                return;

            var prefabSet = SettingsProvider.Get<PrefabsSet>();

            settings.ForEach(toggleSetting =>
            {
                Instantiate(prefabSet.InfoToggle, _toggleParent)
                    .Setup(toggleSetting);
            });
        }

        private void SetDropdown(DropdownSettings settings)
        {
            _dropdownController?.Setup(settings);
        }
    }
}
