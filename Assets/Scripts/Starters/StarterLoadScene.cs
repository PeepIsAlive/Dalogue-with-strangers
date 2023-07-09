using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine;
using Settings;
using Modules;
using Scenes;
using Core;

namespace Starters
{
    public sealed class StarterLoadScene : Starter
    {
        [SerializeField] private SpriteRenderer _background;
        private BackgroundsSettings _settings;

        private void Awake()
        {
            _settings = SettingsProvider.Get<BackgroundsSettings>();
            _background.sprite = _settings.GetRandomBackground();
        }

        private async void Start()
        {
            await Initialize();
        }

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
                presetId = SettingsProvider.Get<NpcCommonSettings>().GetPreset(NpcType.Epsilon).Id;

            await LoadMainScene(presetId);
        }

        private async Task LoadMainScene(string presetId)
        {
            var operation = Main.LoadScene(presetId);
            operation.allowSceneActivation = false;

            await Task.Delay(5000);

            operation.allowSceneActivation = true;
        }
    }
}