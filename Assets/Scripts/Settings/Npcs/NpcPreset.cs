using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "NpcPreset", menuName = "Settings/Npcs/NpcPreset", order = 0)]
    public class NpcPreset : Preset
    {
        [field: Header("Npc settings")]
        [field: SerializeField] public NpcType Type { get; private set; }
        [field: SerializeField] public Color NpcColor {get; private set;}
        [field: SerializeField] public Sprite Background { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}
