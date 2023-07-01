using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "NpcCommonSettings", menuName = "Settings/Npcs/NpcCommonSettings", order = 0)]
    public sealed class NpcCommonSettings : ScriptableObject
    {
        [SerializeField] private List<NpcPreset> _presets;

        public NpcPreset GetPreset(NpcType type)
        {
            return _presets.First(x => x.Type == type);
        }
    }
}
