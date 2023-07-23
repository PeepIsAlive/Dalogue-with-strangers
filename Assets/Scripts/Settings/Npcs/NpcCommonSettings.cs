using System.Collections.Generic;
using Localization;
using System.Linq;
using UnityEngine;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "NpcCommonSettings", menuName = "Settings/Npcs/NpcCommonSettings", order = 0)]
    public sealed class NpcCommonSettings : ScriptableObject
    {
        [SerializeField] private TextResource _localization;
        [SerializeField] private List<NpcPreset> _presets;

        public NpcPreset GetPreset(NpcType type)
        {
            return _presets.First(x => x.Type == type);
        }

        public NpcPreset GetPreset(string id)
        {
            return _presets.First(x => x.Id == id);
        }

        public string GetNpcName(NpcType type)
        {
            return LocalizationProvider.GetText(_localization.LocalizedAsset, $"name/{type}");
        }
    }
}
