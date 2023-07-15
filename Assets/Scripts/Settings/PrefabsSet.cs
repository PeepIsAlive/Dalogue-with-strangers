using System.Collections.Generic;
using UI.Controllers;
using UnityEngine;
using UI;

namespace Settings
{
    [CreateAssetMenu(menuName = "Settings/PrefabsSet", fileName = "PrefabsSet", order = 52)]
    public sealed class PrefabsSet : ScriptableObject
    {
        [field: SerializeField] public List<PopupViewBase> Popups { get; private set; }
        [field: SerializeField] public List<ButtonController> Buttons { get; private set; }
    }
}