using System.Threading.Tasks;
using UnityEngine;
using Settings;
using Scenes;

namespace Starters
{
    public sealed class StarterLoadScene : Starter, ISceneLoadHandler<string>
    {
        [SerializeField] private SpriteRenderer _background;

        private BackgroundsSettings _settings;
        private string _sceneToLoad;

        private void Awake()
        {
            _settings = SettingsProvider.Get<BackgroundsSettings>();
            LoadSceneProcessor.Instance.InvokeLoadAction();
        }

        private async void Start()
        {
            _background.sprite = _settings.GetRandomBackground();
            await Initialize();
        }

        protected override async Task Initialize()
        {
            await Task.Yield();
        }

        public override void OnSceneLoad(string argument)
        {
            _sceneToLoad = argument;

            UnityEngine.Debug.Log(argument);
        }
    }
}