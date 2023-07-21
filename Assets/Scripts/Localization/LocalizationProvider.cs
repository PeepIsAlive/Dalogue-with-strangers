using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using System.Collections.Generic;
using UnityEngine.Localization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using UnityEngine;
using Settings;

namespace Localization
{
    public static class LocalizationProvider
    {
        private static Dictionary<string, LocalizationFileData> _localizationFiles;
        private static LocalizedText _defaultLocalizedText;

        static LocalizationProvider()
        {
            _localizationFiles = new Dictionary<string, LocalizationFileData>();
            _defaultLocalizedText = SettingsProvider.Get<LocalizationProviderSettings>().DefaultAsset;
        }

        public static string GetText(string tag)
        {
            var text = string.Empty;

            var entryName = _defaultLocalizedText.TableReference.TableCollectionName;
            var entryId = _defaultLocalizedText.TableEntryReference.KeyId;

            var key = GetFileDataKey(entryName, entryId);

            if (_localizationFiles.TryGetValue(key, out var fileData))
                fileData.TryGetValue(tag, out text);

            return text;
        }

        public static string GetText(LocalizedText asset, string tag)
        {
            var text = string.Empty;

            var entryName = asset.TableReference.TableCollectionName;
            var entryId = asset.TableEntryReference.KeyId;

            var key = GetFileDataKey(entryName, entryId);

            if (_localizationFiles.TryGetValue(key, out var fileData))
                fileData.TryGetValue(tag, out text);

            return text;
        }

        public static async Task Initialize(Locale locale)
        {
            await Setup(locale);
        }

        private static async Task Setup(Locale locale)
        {
            await LoadLocalization(locale);
        }

        private static async Task LoadLocalization(Locale locale)
        {
            var tables = await LocalizationSettings.AssetDatabase.GetAllTables(locale).Task;
            var tablesEntry = tables.SelectMany(t => t.Values);
            var tasks = new List<Task>();

            foreach (var entry in tablesEntry)
            {
                tasks.Add(LoadLocalizationFile(entry, locale));
            }

            await Task.WhenAll(tasks);
        }

        private static async Task LoadLocalizationFile(AssetTableEntry entry, Locale locale)
        {
            var entryName = entry.Table.TableCollectionName;
            var entryId = entry.KeyId;
            var asset = await LocalizationSettings.AssetDatabase
                .GetLocalizedAssetAsync<TextAsset>(entryName, entryId, locale, FallbackBehavior.UseFallback).Task;

            var localizationFileData = GetFileData(asset);
            var fileKey = GetFileDataKey(entryName, entryId);

            if (!_localizationFiles.ContainsKey(fileKey))
                _localizationFiles.Add(fileKey, localizationFileData);
        }

        private static LocalizationFileData GetFileData(TextAsset asset)
        {
            var data = JsonConvert.DeserializeObject<List<LocalizationItem>>(asset.text);
            var loadedData = new LocalizationFileData();

            data.ForEach(item =>
            {
                var key = string.Join("/", item.Tags);

                if (!loadedData.ContainsKey(key))
                    loadedData.Add(key, item.Topic);
            });

            return loadedData;
        }

        private static string GetFileDataKey(string entryName, long entryId)
        {
            return string.Join("/", new string[] { entryName, entryId.ToString() });
        }
    }
}