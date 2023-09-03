using System.Collections.Generic;
using UnityEngine;
using UI.Settings;

namespace UI
{
    public class Popup
    {
        public Vector3 Direction;
        public bool IgnoreOverlayButtonAction;
    }

    public sealed class DefaultPopup : Popup
    {
        public string Title;
        public string Content;
        public Color? Color = null;
        public List<TextButtonSettings> ButtonSettings;
    }
}