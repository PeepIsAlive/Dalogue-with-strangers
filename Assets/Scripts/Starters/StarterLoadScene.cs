using System.Threading.Tasks;
using UnityEngine;
using Settings;

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
            await Task.Yield();
        }
    }
}