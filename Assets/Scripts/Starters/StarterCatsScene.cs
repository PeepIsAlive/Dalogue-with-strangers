using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using Settings;
using Modules;
using Scenes;
using Core;

namespace Starters
{
    public sealed class StarterCatsScene : Starter
    {
        [SerializeField] private Image _sceneBackground;

        protected override async Task Initialize()
        {
            var npcPreset = SettingsProvider.Get<NpcCommonSettings>().GetPreset(NpcType.Cats);

            npcPreset.Prefabs.ForEach(prefab =>
            {
                Instantiate(prefab);
            });
            _sceneBackground.sprite = npcPreset.Background;

            await Task.Yield();
        }

        private async void Awake()
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;

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