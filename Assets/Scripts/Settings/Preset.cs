using UnityEngine;
using Extentions;
using System;

namespace Settings
{
    public class Preset : ScriptableObject
    {
#if UNITY_EDITOR
        [field: ReadOnly]
#endif
        [field: SerializeField] public string Id { get; private set; }

#if UNITY_EDITOR
        [ContextMenu("Reset id")]
        private void ResetId()
        {
            Id = Guid.NewGuid().ToString();
        }
#endif
    }
}
