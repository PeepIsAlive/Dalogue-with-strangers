using UnityEngine;
using System;

namespace Localization
{
    [Serializable]
    public sealed class TextResource
    {
        [field: SerializeField] public LocalizedText LocalizedAsset { get; private set; }
    }
}