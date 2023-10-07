using UnityEngine;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "CatPreset", menuName = "Settings/Npcs/CatPreset", order = 0)]
    public sealed class CatPreset : NpcPreset
    {
        [field: Header("Cat settings")]
        [field: SerializeField] public CatType CatType { get; private set; }
    }
}