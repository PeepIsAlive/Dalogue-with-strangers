using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using Settings;
using Scenes;

namespace Starters
{
    public sealed class StarterMain : Starter, ISceneLoadHandler<string>
    {
        [SerializeField] private Image _sceneBackground;

        private string _npcPresetId;

        public override void OnSceneLoad(string argument)
        {
            _npcPresetId = argument;
        }

        protected override async Task Initialize()
        {
            var npcPreset = SettingsProvider.Get<NpcCommonSettings>().GetPreset(_npcPresetId);

            _sceneBackground.sprite = npcPreset.Background;

            npcPreset.Prefabs.ForEach(p =>
            {
                Instantiate(p);
            });

            await Task.Yield();
        }

        private async void Awake()
        {
            LoadSceneProcessor.Instance.InvokeLoadAction();
            await Initialize();
        }
    }
}