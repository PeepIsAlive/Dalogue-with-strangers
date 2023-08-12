using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Extensions;

namespace Settings
{
    [CreateAssetMenu(fileName = "BackgroundsSettings", menuName = "Settings/BackgroundsSettings", order = 0)]
    public sealed class BackgroundsSettings : ScriptableObject
    {
        [field: SerializeField] private List<Sprite> _backgrounds;

        public Sprite GetRandomBackground()
        {
            return _backgrounds.GetRandomElement();
        }

#if UNITY_EDITOR
        [ContextMenu("Set backgrounds")]
        private void SetBackgrounds()
        {
            _backgrounds = new List<Sprite>();

            var guids = AssetDatabase.FindAssets("t:Sprite", new string[] { "Assets/Sprites/2048/Backgrounds/Enviroments" });

            foreach (var guid in guids)
            {
                _backgrounds.Add(AssetDatabase.LoadAssetAtPath<Sprite>(AssetDatabase.GUIDToAssetPath(guid)));
            }

            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }
#endif
    }
}