using Localization;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "LocalizationProviderSettings", menuName = "Settings/LocalizationProviderSettings", order = 0)]
    public sealed class LocalizationProviderSettings : ScriptableObject
    {
        [field: SerializeField] public LocalizedText DefaultAsset { get; private set; }
    }
}