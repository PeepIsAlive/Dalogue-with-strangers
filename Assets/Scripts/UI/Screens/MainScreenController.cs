using Application = Live_2D.Application;
using System.Collections.Generic;
using Modules.Managers;
using Localization;
using System.Linq;
using UnityEngine;
using UI.Settings;
using Extensions;
using Settings;
using Modules;
using System;
using Scenes;
using Events;
using TMPro;
using Core;

namespace UI.Controllers
{
    public sealed class MainScreenController : MonoBehaviour
    {
        public event Action OnSendButtonClickEvent;

        [field:Header("For chat")]
        [field:SerializeField] public TMP_InputField InputField { get; private set; }

        [Header("Buttons")]
        [SerializeField] private ImageButtonController _sendButton;
        [SerializeField] private ImageButtonController _menuButton;
        [SerializeField] private ImageButtonController _changeNpcButton;

        private NpcCommonSettings _npcCommonSettings;

        private void OnSendButtonClick()
        {
            EventSystem.Send(new OnMessageSendEvent
            {
                Message = InputField.text,
                NpcType = Application.CurrentNpcType.ToString()
            });

            OnSendButtonClickEvent?.Invoke();
            InputField.text = string.Empty;
        }

        private void OnMenuButtonClick()
        {
            var currentNpcType = Application.CurrentNpcType;
            var color = _npcCommonSettings.GetPreset(currentNpcType).NpcColor;

            PopupExtensions.ShowMenuPopup(color);
        }

        private void OnChangeNpcButtonClick()
        {
            var npcTypes = Enum.GetValues(typeof(NpcType)).OfType<NpcType>().SkipLast(1).ToList();
            var buttonSettings = new List<TextButtonSettings>();
            var currentNpcType = Application.CurrentNpcType;

            npcTypes.Remove(currentNpcType);
            npcTypes.ForEach(type =>
            {
                buttonSettings.Add
                (
                    new TextButtonSettings
                    {
                        Title = _npcCommonSettings.GetNpcName(type),
                        Color = _npcCommonSettings.GetPreset(currentNpcType).NpcColor,
                        Action = () =>
                        {
                            Application.PopupViewManager.HideCurrentPopup();

                            FadeController.Instance.FadeOn(() =>
                            {
                                Main.LoadScene(_npcCommonSettings.GetPreset(type).Id);
                                SaveDataManager.Save(SaveDataManager.NPC_PRESET_KEY, _npcCommonSettings.GetPreset(type).Id);
                            });
                        }
                    }
                );
            });

            buttonSettings.Add
            (
                new TextButtonSettings
                {
                    Title = LocalizationProvider.GetText("button_title/cancel"),
                    Color = _npcCommonSettings.GetPreset(currentNpcType).NpcColor,
                    Action = () =>
                    {
                        Application.PopupViewManager.HideCurrentPopup();
                    }
                }
            );

            PopupExtensions.ShowChangeNpcPopup(_npcCommonSettings.GetPreset(currentNpcType).NpcColor, buttonSettings);
        }

        private void TurnOffInputFieldInteractable(OnTriggerEvent data)
        {
            InputField.interactable = false;
        }

        private async void Start()
        {
            _npcCommonSettings = SettingsProvider.Get<NpcCommonSettings>();

            _sendButton.Setup(new ImageButtonSettings
            {
                Action = OnSendButtonClick
            });
            _menuButton.Setup(new ImageButtonSettings
            {
                Action = OnMenuButtonClick
            });
            _changeNpcButton.Setup(new ImageButtonSettings
            {
                Action = OnChangeNpcButtonClick
            });

            EventSystem.Subscribe<OnTriggerEvent>(TurnOffInputFieldInteractable);
            await AnalyticsManager.Instance.Initialize();
        }

        private void OnDestroy()
        {
            EventSystem.Unsubscribe<OnTriggerEvent>(TurnOffInputFieldInteractable);
        }
    }
}