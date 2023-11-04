using UnityEngine;
using System;

namespace UI.Settings
{
    public class InfoSettings
    {
        public string Content;
        public Color? Color = null;
    }

    public sealed class InfoToggleSettings : InfoSettings
    {
        public Func<bool> Action;
    }
}