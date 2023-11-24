using UnityEngine;

namespace Saves
{
    public sealed class SettingsSaveData
    {
        public SystemLanguage Language = SystemLanguage.English;

        public bool HapticState;
        public bool SoundState;
    }
}