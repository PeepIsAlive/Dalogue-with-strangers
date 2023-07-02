using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "NpcPreset", menuName = "Settings/Npcs/NpcPreset", order = 0)]
    public sealed class NpcPreset : Preset
    {
        [field: SerializeField] public NpcType Type { get; private set; }
        [field: SerializeField] public Sprite Background { get; private set; }
        [field: SerializeField] public List<GameObject> Prefabs { get; private set; }
    }
}
