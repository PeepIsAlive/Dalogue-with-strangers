using System.Threading.Tasks;
using Modules.Managers;
using UnityEngine.UI;
using UnityEngine;
using Settings;
using Scenes;

namespace Starters
{
    public sealed class StarterCatsScene : Starter, ISceneLoadHandler<string>
    {
        [SerializeField] private Image _sceneBackground;
        private string _catPresetId;

        public override void OnSceneLoad(string argument)
        {
            _catPresetId = argument;
        }

        protected override async Task Initialize()
        {
            var npcPreset = SettingsProvider.Get<NpcCommonSettings>().GetPreset(_catPresetId);

            Instantiate(npcPreset.Prefab);
            _sceneBackground.sprite = npcPreset.Background;

            await Task.Yield();
        }

        private async void Awake()
        {
            LoadSceneProcessor.Instance.InvokeLoadAction();
            AnalyticsManager.OnStart();

            await Initialize();
        }

        private void OnDestroy()
        {
            AnalyticsManager.OnDestroy();
        }
    }
}