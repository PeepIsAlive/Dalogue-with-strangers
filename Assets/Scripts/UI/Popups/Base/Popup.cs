using System.Collections.Generic;
using UI.Settings;

namespace UI
{
    public class Popup
    {
        public bool IgnoreOverlayButtonAction;
    }

    public sealed class DefaultPopup : Popup
    {
        public string Title;
        public string Content;
        public List<TextButtonSettings> ButtonSettings;
    }
}