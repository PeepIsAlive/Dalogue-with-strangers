using UnityEngine.Localization.Settings;
using System.Threading.Tasks;
using Localization.Metadata;
using Unity.Services.Core;
using Localization;
using UnityEngine;
using System.Linq;
using Settings;
using Modules;
using Scenes;
using Saves;
using Core;

namespace Starters
{
    public sealed class StarterLoadScene : Starter
    {
        [SerializeField] private SpriteRenderer _background;
        private BackgroundsSettings _settings;

        protected override async Task Initialize()
        {
            var presetId = string.Empty;

            if (SaveDataManager.HasSave(SaveDataManager.NPC_PRESET_KEY))
            {
                SaveDataManager.LoadSave<string>(SaveDataManager.NPC_PRESET_KEY, id =>
                {
                    presetId = id;
                });
            }

            if (string.IsNullOrEmpty(presetId))
                presetId = SettingsProvider.Get<NpcCommonSettings>().GetPreset(NpcType.Natori).Id;

            await SetSettingsStates(GetSettingsStates());
            await LoadMainScene(presetId);
        }

        private async Task LoadMainScene(string presetId)
        {
            var operation = Main.LoadScene(presetId);
            operation.allowSceneActivation = false;

            await Task.Delay(8000);

            operation.allowSceneActivation = true;
        }

        private SettingsSaveData GetSettingsStates()
        {
            var settingsStates = new SettingsSaveData();

            if (SaveDataManager.HasSave(SaveDataManager.SETTINGS_KEY))
            {
                SaveDataManager.LoadSave<SettingsSaveData>(SaveDataManager.SETTINGS_KEY, saveData =>
                {
                    settingsStates = saveData;
                });
            }

            return settingsStates;
        }

        private async Task SetSettingsStates(SettingsSaveData settingsSaveData)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales
                .First(l => l.Metadata.GetMetadata<SystemLanguageMetadata>().SystemLanguage == settingsSaveData.Language);
            HapticProvider.SetState(settingsSaveData.HapticState);
            SoundProvider.SetState(settingsSaveData.SoundState);

            await LocalizationProvider.Initialize(LocalizationSettings.SelectedLocale);
        }

        private async void Awake()
        {
            await UnityServices.InitializeAsync();

#if !UNITY_EDITOR
            Application.targetFrameRate = 60;
#endif
            _settings = SettingsProvider.Get<BackgroundsSettings>();
            _background.sprite = _settings.GetRandomBackground();
        }

        private async void Start()
        {
            await Initialize();
        }
    }
}