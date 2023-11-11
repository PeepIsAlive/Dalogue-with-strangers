using System.Collections.Generic;
using UnityEngine;
using UI.Settings;

namespace UI
{
    public class Popup
    {
        public string Title;
        public Color? Color = null;
        public Vector3 Direction;
        public bool IgnoreOverlayButtonAction;
        public List<TextButtonSettings> ButtonSettings;
    }

    public sealed class DefaultPopup : Popup
    {
        public string Content;
    }

    public sealed class MenuPopup: Popup
    {
        public DropdownSettings DropdownSettings;
        public List<InfoToggleSettings> InfoToggleSettings;
    }
}