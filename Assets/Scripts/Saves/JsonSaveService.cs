using Newtonsoft.Json;
using UnityEngine;
using System.IO;
using System;

namespace Services.Saves
{
    public sealed class JsonSaveService : ISaveService
    {
        private const string SAVE_POSFIX = ".save";

        public bool SaveIsExist(string key)
        {
            return File.Exists(Path.Combine(Application.persistentDataPath, key) + SAVE_POSFIX);
        }

        public void Load<T>(string key, Action<T> callback)
        {
            if (string.IsNullOrEmpty(key))
            {
#if UNITY_EDITOR
                Debug.LogWarning("key is null or empty");
#endif
                return;
            }

            var path = GetPath(key) + SAVE_POSFIX;

            using (var sr = new StreamReader(path))
            {
                var json = sr.ReadToEnd();
                var data = JsonConvert.DeserializeObject<T>(json);

                callback?.Invoke(data);
            }
        }

        public void Save(string key, object data, Action<bool> callback = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                callback?.Invoke(false);
                return;
            }

            var path = GetPath(key) + SAVE_POSFIX;
            var json = JsonConvert.SerializeObject(data);

            Directory.CreateDirectory(GetPath(key));

            using (var sw = new StreamWriter(path))
            {
                sw.Write(string.Empty);
                sw.Write(json);
            }

            callback?.Invoke(true);
        }

        private static string GetPath(string key)
        {
            return Path.Combine(Application.persistentDataPath, key);
        }
    }
}
