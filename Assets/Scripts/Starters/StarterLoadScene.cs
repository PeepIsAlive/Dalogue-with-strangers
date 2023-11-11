using UnityEngine.Localization.Settings;
using Unity.Services.Analytics;
using System.Threading.Tasks;
using Unity.Services.Core;
using Localization;
using UnityEngine;
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

            SetSettingsStates();

            await LocalizationProvider.Initialize(LocalizationSettings.ProjectLocale);
            await LoadMainScene(presetId);
        }

        private async Task LoadMainScene(string presetId)
        {
            var operation = Main.LoadScene(presetId);
            operation.allowSceneActivation = false;

            await Task.Delay(8000);

            operation.allowSceneActivation = true;
        }

        private void SetSettingsStates()
        {
            if (SaveDataManager.HasSave(SaveDataManager.SETTINGS_KEY))
            {
                SaveDataManager.LoadSave<SettingsSaveData>(SaveDataManager.SETTINGS_KEY, saveData =>
                {
                    HapticProvider.SetState(saveData.HapticState);
                    SoundProvider.SetState(saveData.SoundState);
                });
            }
        }

        private async void Awake()
        {
#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
            Application.targetFrameRate = 60;
#endif
            _settings = SettingsProvider.Get<BackgroundsSettings>();
            _background.sprite = _settings.GetRandomBackground();

            await UnityServices.InitializeAsync();
        }

        private async void Start()
        {
            await Initialize();
        }
    }
}