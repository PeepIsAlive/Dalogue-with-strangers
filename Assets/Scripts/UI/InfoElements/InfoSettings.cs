using UnityEngine;
using System;

namespace UI.Settings
{
    public class InfoSettings
    {
        public string Title;
        public Color? Color = null;
    }

    public sealed class InfoToggleSettings : InfoSettings
    {
        public bool StartState;
        public Func<bool> Action;
    }
}