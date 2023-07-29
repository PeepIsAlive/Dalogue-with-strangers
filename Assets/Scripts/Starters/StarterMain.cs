using Application = Live_2D.Application;
using System.Threading.Tasks;
using Inworld.Sample;
using UnityEngine.UI;
using UI.Controllers;
using System.Linq;
using UnityEngine;
using Settings;
using Inworld;
using Scenes;

namespace Starters
{
    public sealed class StarterMain : Starter, ISceneLoadHandler<string>
    {
        [Header("Controllers")]
        [SerializeField] private InworldController _inworldController;
        [SerializeField] private MainScreenController _mainScreenController;
        [Space][SerializeField] private Image _sceneBackground;

        private string _npcPresetId;

        public override void OnSceneLoad(string argument)
        {
            _npcPresetId = argument;
        }

        protected override async Task Initialize()
        {
            var npcPreset = SettingsProvider.Get<NpcCommonSettings>().GetPreset(_npcPresetId);
            var npc = Instantiate(npcPreset.Prefabs.First());

            _sceneBackground.sprite = npcPreset.Background;

            NpcInitialize(npc);

            await Task.Yield();
        }

        private void NpcInitialize(GameObject npc)
        {
            if (_mainScreenController == null)
                return;

            if (npc.TryGetComponent<NpcController>(out var controller))
            {
                var inworldPlayer = controller.InworldPlayer;

                inworldPlayer.SetGlobalCanvas(Application.MainCanvasRect.gameObject);
                inworldPlayer.SetInputField(_mainScreenController.InputField);

                InworldController.Player = npc;

                _inworldController.CurrentCharacter = controller.InworldCharacter;
                _mainScreenController.OnSendButtonClick += inworldPlayer.SendText;
            }
        }

        private async void Awake()
        {
            LoadSceneProcessor.Instance.InvokeLoadAction();
            await Initialize();
        }
    }
}