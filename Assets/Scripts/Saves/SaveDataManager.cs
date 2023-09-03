using Services.Saves;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

namespace Modules
{
    public static class SaveDataManager
    {
        public const string NPC_PRESET_KEY = "npc_preset_id";

        private static readonly JsonSaveService _jsonService;
        private static readonly PrefsSaveService _prefsService;

        static SaveDataManager()
        {
            _jsonService = new JsonSaveService();
            _prefsService = new PrefsSaveService();
        }

        #region json service
        public static bool HasSave(string key)
        {
            return _jsonService.SaveIsExist(key);
        }

        public static void Save(string key, object data, Action<bool> callback = null)
        {
            _jsonService.Save(key, data, callback);
        }

        public static void LoadSave<T>(string key, Action<T> callback)
        {
            _jsonService.Load(key, callback);
        }
        #endregion

        public static void SavePrefs(string key, object data, Action<bool> callback = null)
        {
            _prefsService.Save(key, data, callback);
        }

        public static void LoadPrefs<T>(string key, Action<T> callback)
        {
            _prefsService.Load(key, callback);
        }

#if UNITY_EDITOR
        [MenuItem("Saves/Clear saves")]
        public static void ClearSaves()
        {
            var saves = Directory.EnumerateFiles(Application.persistentDataPath);

            foreach (var save in saves)
            {
                File.Delete(save);
            }
        }

        [MenuItem("Saves/Clear prefs")]
        public static void ClearPrefs()
        {

        }
#endif
    }
}