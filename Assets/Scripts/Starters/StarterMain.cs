using Application = Live_2D.Application;
using System.Threading.Tasks;
using Modules.Managers;
using UnityEngine.UI;
using UI.Controllers;
using Controllers;
using UnityEngine;
using Settings;
using Inworld;
using Modules;
using Scenes;
using Events;
using System;
using Core;

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
            var npc = Instantiate(npcPreset.Prefab);

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
                _mainScreenController.OnSendButtonClickEvent += inworldPlayer.SendText;

                controller.InworldCharacter.OnGoalCompleted.AddListener(goal =>
                {
                    if (!Enum.TryParse<TriggerType>(goal, out var triggerType))
                        return;

                    EventSystem.Send(new OnTriggerEvent
                    {
                        TriggerType = triggerType
                    });
                });
            }
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