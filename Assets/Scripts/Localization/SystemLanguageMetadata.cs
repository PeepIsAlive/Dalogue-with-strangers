using UnityEngine.Localization.Metadata;
using System.ComponentModel;
using UnityEngine;
using System;

namespace Localization.Metadata
{
    [DisplayName("System language")]
    [Metadata(AllowedTypes = MetadataType.Locale)]
    [Serializable]
    public sealed class SystemLanguageMetadata : IMetadata
    {
        public SystemLanguage SystemLanguage;
    }
}
